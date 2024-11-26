function createElementFromHTML(htmlString) {
    var div = document.createElement('div');
    div.innerHTML = htmlString.trim();
    return div.firstChild;
}

document.addEventListener('DOMContentLoaded', function () {

    document.querySelector('ul#users-list').addEventListener('click', function (event) {
        if (event.target.tagName === 'LI') {
            var username = event.target.dataset.username;
            var input = document.getElementById('message-input');
            var text = input.value;
            if (text.startsWith("/")) {
                text = text.split(")")[1];
            }

            text = "/private(" + username + ") " + text.trim();
            input.value = text;
            input.dispatchEvent(new Event('change'));
            input.focus();
        }
    });
    document.getElementById("btn-show-emojis").addEventListener('click', function () {
        document.getElementById("emojis-container").classList.toggle("d-none");
    });

    document.getElementById("message-input").addEventListener('click', hideEmojis);
    document.querySelector('.messages-container').addEventListener('click', hideEmojis);
    document.getElementById("btn-send-message").addEventListener('click', hideEmojis);
    document.querySelectorAll('#emojis-container button').forEach(button => {
        button.addEventListener('click', function () {
            var emojiValue = this.dataset.value;
            var input = document.getElementById('message-input');
            input.value += emojiValue + " ";
            input.focus();
            input.dispatchEvent(new Event('change'));
        });
    });

    function hideEmojis() {
        document.getElementById("emojis-container").classList.add("d-none");
    }

    document.getElementById("expand-sidebar").addEventListener('click', function () {
        document.querySelector(".sidebar").classList.toggle("open");
        document.querySelector(".users-container").classList.remove("open");
    });

    document.getElementById("expand-users-list").addEventListener('click', function () {
        document.querySelector(".users-container").classList.toggle("open");
        document.querySelector(".sidebar").classList.remove("open");
    });

    document.querySelectorAll(".sidebar.open ul li a, #users-list li").forEach(function (el) {
        el.addEventListener('click', function () {
            document.querySelector(".sidebar").classList.remove("open");
            document.querySelector(".users-container").classList.remove("open");
        });
    });

    document.querySelectorAll('.modal').forEach(function (modal) {
        modal.addEventListener('shown.bs.modal', function () {
            modal.querySelector('input[type=text]:first-child').focus();
        });

        modal.addEventListener('hidden.bs.modal', function () {
            document.querySelectorAll(".modal-body input:not(#newRoomName)").forEach(function (input) {
                input.value = "";
            });
        });
    });

    document.querySelectorAll(".alert .btn-close").forEach(function (button) {
        button.addEventListener('click', function () {
            this.parentElement.style.display = "none";
        });
    });

    document.querySelectorAll('[data-bs-toggle="tooltip"]').forEach(function (element) {
        new bootstrap.Tooltip(element, { delay: { show: 500 } });
    });

    document.getElementById("remove-message-modal").addEventListener("shown.bs.modal", function (e) {
        const id = e.relatedTarget.getAttribute('data-messageId');
        document.getElementById("itemToDelete").value = id;
    });

    document.addEventListener("mouseenter", function (e) {
        if (e.target.classList.contains("ismine")) {
            e.target.querySelector(".actions").classList.remove("d-none");
        }
    });

    document.addEventListener("mouseleave", function (e) {
        if (e.target.classList.contains("ismine")) {
            var dropdownOpen = e.target.querySelector(".dropdown-menu.show");
            if (!dropdownOpen) {
                e.target.querySelector(".actions").classList.add("d-none");
            }
        }
    });

    document.addEventListener("hidden.bs.dropdown", function (e) {
        if (e.target.closest(".actions")) {
            e.target.closest(".actions").classList.add("d-none");
        }
    });

});

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().catch(function (err) {
    console.error(err);
});

connection.on("newMessage", function (messageView) {
    var isMine = messageView.fromFullName === username;
    var message = new ChatMessage(messageView.id, messageView.content, messageView.timestamp, messageView.fromUserName, isMine);
    chatMessages.push(message);
    appendMessage(message);
});

connection.on("deleteMessage", function (msgId) {
    var messageElement = document.querySelector(`[data-message-id="${msgId}"]`);
    if (messageElement) {
        messageElement.remove();
    }
    console.log(`Message ${msgId} deleted via SignalR.`);
});

connection.on("onError", function (message) {
    viewModel.serverInfoMessage(message);
    var errorAlert = document.getElementById("errorAlert");
    errorAlert.classList.remove("d-none");
    errorAlert.style.display = "block";
    setTimeout(function () {
        errorAlert.style.display = "none";
    }, 5000);
});

let joinedRoomName = "";
let chatMessages = [];
let noJoinedRoomPanel;
let roomContainer;
let joinedRoomNameElement;
let messagesContainer;
let messageInputField;

document.addEventListener('DOMContentLoaded', function () {
    noJoinedRoomPanel = document.getElementById("noJoinedRoomPanel");
    roomContainer = document.getElementById("messagesPanel");
    joinedRoomNameElement = document.getElementById("joinedRoomName");
    messagesContainer = document.getElementById("messages");
    messageInputField = document.getElementById("messageInputField");
});

function joinRoom(roomName) {
    connection.invoke("Join", roomName).then(function () {
        joinedRoomName = roomName;
        viewRoomAndMessages();
        messageHistory();
    });
}

function sendToRoom(event) {
    if ((event.keyCode && event.keyCode === 13) || !event.keyCode) {
        let message = messageInputField.value;
        messageInputField.value = "";

        let encodedMessage = encodeURIComponent(message);
        let encodedRoom = encodeURIComponent(joinedRoomName);

        fetch(`/Messages/Create?content=${encodedMessage}&room=${encodedRoom}&userId=${userId}`, { method: 'GET' });
    }
}

function viewRoomAndMessages() {
    noJoinedRoomPanel.style.display = "none";
    roomContainer.style.display = "block";
    joinedRoomNameElement.textContent = joinedRoomName;

    setTimeout(() => scrollToBottom(), 100);
}

function messageHistory() {
    fetch('/Messages/Room/' + encodeURIComponent(joinedRoomName))
        .then(response => response.json())
        .then(data => {
            chatMessages = data.map(function (msg) {
                var isMine = msg.fromFullName === username;
                return new ChatMessage(msg.id, msg.content, msg.timestamp, msg.fromUserName, isMine);
            });
            appendMessages();
        });
}

function appendMessages() {
    messagesContainer.innerHTML = "";
    chatMessages.forEach(function (message) {
        appendMessage(message);
    });
    scrollToBottom();
}

function appendMessage(message) {
    var messageElement;
    if (message.isMine) {
        messageElement = createElementFromHTML(mineMessage(message.content, message.timestampRelative, message.id));
    } else {
        messageElement = createElementFromHTML(notMineMessage(message.content, message.timestampRelative, message.id));
    }
    messagesContainer.appendChild(messageElement);
    scrollToBottom();
}

function scrollToBottom() {
    if (messagesContainer) {
        messagesContainer.scrollTop = messagesContainer.scrollHeight;
    }
}

function notMineMessage(content, timestampFull) {
    return `
        <div class="left-chat-message fs-13 mb-2">
            <p class="mb-0 mr-3 pr-4">${content}</p>
            <div class="message-time">${timestampFull}</div>
            <div class="message-options"></div>
        </div>
    `;
}

function mineMessage(content, timestampFull, id) {
    return `
        <div class="right-chat-message fs-13 mb-2" data-message-id="${id}">
            <div class="mb-0 mr-3 pr-4">
                <div class="d-flex flex-row">
                    <div class="pr-2">${content}</div>
                </div>
            </div>
            <div class="message-options dark">
                <div class="message-time">
                    <div class="d-flex flex-row align-items-center">
                        <div class="mr-2 message-text-tooltip">${timestampFull}</div>
                        <div class="svg15 double-check"></div>
                    </div>
                </div>
                <button 
                    class="btn btn-icon delete-btn"
                    onclick="deleteMessage('${id}')"
                    title="Delete this message">
                    <i class="fas fa-trash delete-icon" style="font-size: 16px; color: red;"></i>
                </button>
            </div>
        </div>
    `;
}

function deleteMessage(id) {
    fetch(`/Messages/Delete/${id}`)
        .then(response => {
            if (response.ok) {
                var messageElement = document.querySelector(`[data-message-id="${id}"]`);
                if (messageElement) {
                    messageElement.remove();
                }
                console.log(`Message ${id} deleted successfully.`);
            } else {
                console.error(`Failed to delete message ${id}.`);
            }
        })
        .catch(error => console.error('Error deleting message:', error));
}

function ChatMessage(id, content, timestamp, fromUserName, isMine) {
    var self = this;
    self.id = id;
    self.content = content;
    self.timestamp = timestamp;
    var date = new Date(timestamp);
    var now = new Date();
    var diff = Math.round((date.getTime() - now.getTime()) / (1000 * 3600 * 24));

    var { dateOnly, timeOnly } = formatDate(date);
    if (diff == 0) self.timestampRelative = `${timeOnly}`;
    else if (diff == -1) self.timestampRelative = `Yesterday`;
    else self.timestampRelative = `${dateOnly}`;

    self.time = timeOnly;
    self.fromUserName = fromUserName;
    self.isMine = isMine;
}

function formatDate(date) {
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var day = date.getDate();
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var d = hours >= 12 ? "PM" : "AM";

    if (hours > 12) hours = hours % 12;
    if (minutes < 10) minutes = "0" + minutes;

    var dateOnly = `${day}/${month}/${year}`;
    var timeOnly = `${hours}:${minutes} ${d}`;
    return { dateOnly, timeOnly };
}