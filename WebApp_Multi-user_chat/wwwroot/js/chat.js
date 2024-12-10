$(document).ready(function () {
    $('#loginBtn').click(function () {
        const username = $('#username').val();
        const password = $('#password').val();

        if (!username || !password) {
            alert('Veuillez remplir tous les champs.');
            return;
        }

        // Requête AJAX avec jQuery
        $.ajax({
            url: '/api/authenticate', 
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ userName: username, password: password }),
            success: function (data) {
                if (data) {
                    // Masquer la section de connexion et afficher la section de chat
                    localStorage.setItem("user", JSON.stringify(data))
                    window.location.href = '/Home/Chat';
                    $('#loginSection').hide();
                    $('#chatSection').show();
                } else {
                    alert('Échec de la connexion : ' + data.message);
                }
            },
            error: function (xhr, status, error) {
                console.error('Erreur AJAX :', error);
                alert('Échec de la connexion : ' + error);
            }
        });
    });


    $(document).ready(function () {
        $.ajax({
            url: '/api/users',
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                let memberList = $('#membersList');
                memberList.empty();

                data.forEach(memberItem => {
                    console.log(memberItem);
                    let firstLetter = memberItem.userName.charAt(0).toUpperCase();
                    let member = `
                                            <li class="p-2">
                                                <a href="#!" class="d-flex align-items-center text-decoration-none text-light" data-userid="${memberItem.id}" data-username="${memberItem.userName}">
                                                    <div class="d-flex align-items-center justify-content-center rounded-circle bg-primary text-white fw-bold" style="width: 40px; height: 40px;">
                                                        ${firstLetter}
                                                    </div>
                                                    <div class="ms-3">
                                                        <p class="fw-bold mb-0">${memberItem.userName}</p>
                                                    </div>
                                                </a>
                                            </li>
                                        `;
                    memberList.append(member);
                });

                // Event listener pour démarrer une conversation
                $('#membersList a').on('click', function (e) {
                    e.preventDefault();
                    let userId = $(this).data('userid');
                    let userName = $(this).data('username');

                    // Mettre à jour la section de chat et afficher le nom de l'utilisateur
                    $('#chatSection').show();
                    $('#chatWithUser').show();
                    $('#chatUserName').text(userName); // Afficher le nom de l'utilisateur dans le chat

                    // Vous pouvez ici appeler une fonction pour charger les messages du chat
                    startChat(userId);
                });

            },
            error: function (xhr, status, error) {
                console.log("Status:", status);
                console.error("Erreur: ", error);
                console.log("Réponse complète: ", xhr.responseText);
            }
        });
    });

    function startChat(userId) {
        console.log("Démarrer le chat avec l'utilisateur ID:", userId);
        // Par exemple, charger les messages du chat avec l'ID de l'utilisateur
    }
});