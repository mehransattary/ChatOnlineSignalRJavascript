
//#region Start Connection
var chatBox = $("#ChatBox");
var activeAdminConnectionId = '';
var activeUserConnectionId = '';

var UserConnectionId = '';
var activeAdminUserId = '';

var _Clients = [];

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();
connection.start();

//اتصال با هاب کانکشن پشتیبانی
var supportConnection = new signalR.HubConnectionBuilder()
    .withUrl('/supporthub')
    .build();
supportConnection.start();


connection.on("ShowError", function (message) {
    console.log('Error desconnected :' + message);
});
//#endregion
//******************************************* */
//#region User Connected
connection.on("UserConnected", function (userId) {

    var client = _Clients.find(x => x.id == userId);
    $(`#userRightSidebar-${client.id}`).remove();
    client.isOnline = true;

    AddPrependClient(client);
});
connection.on("disableOnlineUser", function (userId) {

    var client = _Clients.find(x => x.id == userId);
    $(`#userRightSidebar-${client.id}`).remove();
    client.isOnline = false;
    AddAppendClient(client);
});

//#endregion
//******************************************* */
//#region Single Client
function AddPrependClient(client) {
    if (!client) return;
    $("#userList").prepend(`
    <li class="" data-to="chating" id="userRightSidebar-${client['id']}"  >
    <div class="chat-box">
       <a href="#"  onclick="showMessagesSupport('${client['id']}')">

            <div class="profile ${client['isOnline'] == true ? 'online' : ''}">                    
                    <img class="bg-img w-75" src="${client['avatarImage']}"alt="Avatar" />                                                              
            </div>

            <div class="details">
                <h5> ${client['fullName'] != null ? client['fullName'] : client['phoneNumber']}</h5>
                <h6> 021-74612  </h6>
            </div>

            <div class="date-status">
                <i class="ti-pin2"></i>
               <h6>${client['branche'] != null ? client['branche'] : ''}</h6>
    
            </div>

         </a>
    </div>
</li>


         
    `);
}
function AddAppendClient(client) {
    if (!client) return;
    $("#userList").append(`
    <li class="" data-to="chating" id="userRightSidebar-${client['id']}"  >
    <div class="chat-box">
       <a href="#"  onclick="showMessagesSupport('${client['id']}')">

            <div class="profile ${client['isOnline'] == true ? 'online' : ''}">                    
                    <img class="bg-img w-75" src="${client['avatarImage']}"alt="Avatar" />                                                              
            </div>

            <div class="details">
                <h5> ${client['fullName'] != null ? client['fullName'] : client['phoneNumber']}</h5>
                <h6> 021-74612  </h6>
            </div>

            <div class="date-status">
                <i class="ti-pin2"></i>
               <h6>${client['branche'] != null ? client['branche'] : ''}</h6>
    
            </div>

         </a>
    </div>
</li>


         
    `);
}
//#endregion
//******************************************* */
//#region  Get Admin Clients
connection.on('GetAdminClients', loadClients);
function loadClients(clients) {

    _Clients = clients;

    if (!clients) return;
    var clientIds = Object.keys(clients);
    if (!clientIds.length) return;

    clientIds.forEach(function (id) {
        var clientInfo = clients[id];
        if (!clientInfo) return;
        // مدیران
        return $("#userList").append(`
            <li class="" data-to="chating" id="userRightSidebar-${clientInfo['id']}" >
                <div class="chat-box">
                    <a id="client-${clientInfo['id']}" href="#" onclick="showMessagesUser('${clientInfo['id']}')">

                        <div class="profile  ${clientInfo['isOnline'] == true ? 'online' : ''}">   
                                <img class="bg-img w-75" src="${clientInfo['avatarImage']}"alt="Avatar" />                                                              
                             
                        </div>

                        <div class="details">
                        <h5> ${clientInfo['fullName'] != null ? clientInfo['fullName'] : clientInfo['phoneNumber']}</h5>

                            <h6> 021-74612  </h6>
                        </div>

                        <div class="date-status">
                            <i class="ti-pin2"></i>
                            <h6>${clientInfo['branche']}</h6>   
                      
                           
                        </div>
                      </a>
                   
                </div>
            </li>


     
        `);

    });

}
//#endregion
//******************************************* */
//#region  Show Messages  adminUserId
function showMessagesUser(adminUserId) {
    $(".chitchat-container").toggleClass("mobile-menu");

    //#region  Remove class active for clients and LeaveGrop
    if (activeAdminUserId != '' && $(`#userRightSidebar-${activeAdminUserId}`).hasClass('active')) {
        connection.invoke('LeaveGrop', activeAdminUserId);
        document.getElementById(`userRightSidebar-${activeAdminUserId}`).classList.remove('active');
        document.getElementById(`userRightSidebar-${activeAdminUserId}`).style.pointerEvents = "auto";
    }
    //#endregion
    activeAdminUserId = adminUserId;

    //#region  SelectAdminClient

    connection.invoke('SelectAdminClient', activeAdminUserId);
    connection.on('getConnectionIds', setConnectionIds);

    function setConnectionIds(userConnectionId, adminUserConnectionId) {


        activeUserConnectionId = userConnectionId;
        activeAdminConnectionId = adminUserConnectionId;

        //#region  Add class active for clients
        document.getElementById(`userRightSidebar-${activeAdminUserId}`).classList.add('active');
        document.getElementById(`userRightSidebar-${activeAdminUserId}`).style.pointerEvents = "none";
        //#endregion
    }

    //#endregion

}
//#endregion
//******************************************* */
//#region  Get Message
connection.on('getNewMessage', getMessage);
supportConnection.on('getNewMessage', getMessage);

function getMessage(message) {

    if (!message) return;
    if (message['isAdmin'] == true) {
        newAppendToAdminMessage(message['user'], message['time'], message['date'], message['avatarImage'], message['messageText']);
    }
    else {
        newAppendToUserMessage(message['user'], message['time'], message['date'], message['avatarImage'], message['messageText']);
    }
    scrollMessagesIntoView();
};
//#endregion
//******************************************* */
//#region  Get Messages
connection.on('getNewMessages', getMessages);
function getMessages(messages) {
    $(".messages .chatappend li").remove();

    if (!messages) return;
    var messagesId = Object.keys(messages);
    if (!messagesId.length) return;

    for (let i = 0; i < messagesId.length; i++) {

        var messageInfo = messages[i];

        if (!messageInfo) return;

        if (messageInfo['isAdmin'] == true) {
            newAppendToAdminMessage(messageInfo['user'], messageInfo['time'], messageInfo['date'], messageInfo['avatarImage'], messageInfo['messageText']);
        }
        else {
            newAppendToUserMessage(messageInfo['user'], messageInfo['time'], messageInfo['date'], messageInfo['avatarImage'], messageInfo['messageText']);
        }
    }
    scrollMessagesIntoView();


};
//#endregion
//******************************************* */
//#region  AppendTo
function newAppendToUserMessage(fullname, time, date, avatarImage, messageText) {
    $(
        `<li class="replies">
                     <div class="media">
                         <div class="profile mr-4" style="background-image: url('${avatarImage}'); 
                         background-size: cover; background-position: center center;">
                         </div>
                         <div class="media-body">
                             <div class="contact-name">
                                 <h5>${fullname} </h5>
                                 <h6>${date} - ${time}</h6>
                                 <ul class="msg-box">
                                     <li class="msg-setting-main">
                                         <h5>${messageText}</h5>
                                     </li>
                                 </ul>
                             </div>
                         </div>
                     </div>
                 </li>`
    ).appendTo($(".messages .chatappend"));
    //$(".message-input input").val(null);
    //$(".chat-main .active .details h6").html("<span>شما : </span>" + message);
    // $(".messages").animate({ scrollTop: $(document).height() }, "fast");
}
function newAppendToAdminMessage(fullname, time, date, avatarImage, messageText) {

    $(
        ` <li class="sent">
                <div class="media">
                          <div class="profile mr-4" style="background-image: url('${avatarImage}'); 
                                  background-size: cover; background-position: center center;">
                         </div>      
                       <div class="media-body">
                        <div class="contact-name">
                            <h5>${fullname} </h5>
                            <h6>${date} - ${time}</h6>
                            <ul class="msg-box">
                                <li class="msg-setting-main">
                                      <h5>${messageText} </h5>                                   
                                </li>                              
                            </ul>
                        </div>
                    </div>
                </div>
            </li>`
    ).appendTo($(".messages .chatappend"));
    //$(".message-input input").val(null);
    //$(".chat-main .active .details h6").html("<span>شما : </span>" + message);
    // $(".messages").animate({ scrollTop: $(document).height() }, "fast");
}
//#endregion
//******************************************* */
//#region Send Message

function sendMessage(text) {
    connection.invoke('SendNewMessage', activeAdminUserId, text);
}
//#endregion
//******************************************* */
//#region scrollMessagesIntoView Message
function scrollMessagesIntoView() {
    var messages = document.getElementById('messages');
    var lastMessage = messages.lastElementChild;

    // اسکرول کردن به آخرین عنصر
    lastMessage.scrollIntoView();
}
//#endregion
//******************************************* */
//#region searchUser Message
function searchUser() {

    var value = document.getElementById('searchuser').value;

    if (value != null && value != undefined && _Clients) {
        var filteredClients = _Clients.filter(x => x.fullName?.includes(value) ||x.phoneNumber?.includes(value));
        $("#userList li").remove();
        loadClientsSearched(filteredClients);

    }
    else {
        $("#userList li").remove();
        loadClients(_Clients);
    }
}
function loadClientsSearched(clients) {


    if (!clients) return;
    var clientIds = Object.keys(clients);
    if (!clientIds.length) return;

    clientIds.forEach(function (id) {
        var clientInfo = clients[id];
        if (!clientInfo) return;
        // مدیران
        return $("#userList").append(`
            <li class="" data-to="chating" id="userRightSidebar-${clientInfo['id']}" >
                <div class="chat-box">
                    <a id="client-${clientInfo['id']}" href="#" onclick="showMessagesUser('${clientInfo['id']}')">

                        <div class="profile  ${clientInfo['isOnline'] == true ? 'online' : ''}">   
                                <img class="bg-img w-75" src="${clientInfo['avatarImage']}"alt="Avatar" />                                                              
                             
                        </div>

                        <div class="details">
                        <h5> ${clientInfo['fullName'] != null ? clientInfo['fullName'] : clientInfo['phoneNumber']}</h5>
                            <h6> 021-74612  </h6>
                        </div>

                        <div class="date-status">
                            <i class="ti-pin2"></i>
                            <h6>${clientInfo['branche']}</h6>   
                      
                           
                        </div>
                      </a>
                   
                </div>
            </li>


     
        `);

    });

}
//#endregion







