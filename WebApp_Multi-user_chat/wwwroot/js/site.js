
// change hidden password to visible password
for (var i = 0; i < passwordIcon.length; ++i) {
    passwordIcon[i].addEventListener('click', (i) => {
        const lastArray = i.target.classList.length - 1
        if (i.target.classList[lastArray] == 'bi-eye-slash') {
            i.target.classList.remove('bi-eye-slash')
            i.target.classList.add('bi-eye')
            i.currentTarget.parentNode.querySelector('input').type = 'text'
        } else {
            i.target.classList.add('bi-eye-slash')
            i.target.classList.remove('bi-eye')
            i.currentTarget.parentNode.querySelector('input').type = 'password'
        }
    });
}






let userId; // Selected user ID
const newMessagesMap = {}; // To track new messages per user

$(document).ready(function () {
    // Fetch online members
    $.ajax({
        url: '/api/users',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            let memberList = $('#membersList');
            memberList.empty();

            data.forEach(memberItem => {
                let firstLetter = memberItem.userName.charAt(0).toUpperCase();
                let member = `
                                <li class="p-2" id="member-${memberItem.id}">
                                    <a href="#!" class="d-flex align-items-center text-decoration-none text-light" data-userid="${memberItem.id}" data-username="${memberItem.userName}">
                                        <div class="d-flex align-items-center justify-content-center rounded-circle bg-primary text-white fw-bold" style="width: 40px; height: 40px;">
                                            ${firstLetter}
                                        </div>
                                        <div class="ms-3">
                                            <p class="fw-bold mb-0">${memberItem.userName}</p>
                                            <span class="badge bg-danger text-white ms-2 new-message-indicator" style="display: none;">New</span>
                                        </div>
                                    </a>
                                </li>
                            `;
                memberList.append(member);
            });

            // Event listener for starting a chat
            $('#membersList a').on('click', function (e) {
                e.preventDefault();
                userId = $(this).data('userid');
                let userName = $(this).data('username');

                // Update the chat section UI
                $('#chatSection').show();
                $('#chatUserName').text(userName);

                // Mark messages as read and hide the "new message" badge
                newMessagesMap[userId] = false;
                $(`#member-${userId} .new-message-indicator`).hide();

                // Fetch chat messages for this user
                fetchMessages(userId);
            });
        },
        error: function (xhr, status, error) {
            console.error('Error fetching users:', error);
        }
    });

    // Poll for new messages every 2 seconds
    setInterval(() => pollNewMessages(), 2000);
});

// Fetch chat messages for the selected user
function fetchMessages(userId) {
    if (!userId) return;

    const senderId = JSON.parse(localStorage.getItem("user")).id;

    $.ajax({
        url: `/api/messages?senderId=${senderId}&receiverId=${userId}`,
        method: 'GET',
        dataType: 'json',
        success: function (messages) {
            const messagesList = $('#messagesList');
            messagesList.empty();

            messages.forEach(message => {
                const messageClass = message.senderId === senderId ? 'message-sent' : 'message-received';
                messagesList.append(`
                                <li class="${messageClass}">
                                    <strong>${message.senderId === senderId ? 'You' : 'Them'}:</strong> ${message.message}
                                </li>
                            `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Error fetching messages:', error);
        }
    });
}

// Poll for new messages for all users
function pollNewMessages() {
    const currentUserId = JSON.parse(localStorage.getItem("user")).id;

    $.ajax({
        url: `/api/messages/new-messages/${currentUserId}`,
        method: 'GET',
        dataType: 'json',
        success: function (newMessages) {
            newMessages.forEach(message => {
                if (message.senderId !== userId) { // Only mark if not in the current chat
                    newMessagesMap[message.senderId] = true;
                    $(`#member-${message.senderId} .new-message-indicator`).show();
                }
            });
        },
        error: function (xhr, status, error) {
            console.error('Error polling new messages:', error);
        }
    });
}

setInterval(() => fetchMessages(userId), 2000);





