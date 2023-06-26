

//******************************************* */
//#region Start Connection
var activeAdminConnectionId = '';
var activeUserConnectionId = '';
var activeUserId = '';
var _Clients = [];

//اتصال با هاب کانکشن پشتیبانی
var supportConnection = new signalR.HubConnectionBuilder()
    .withUrl('/supporthub')
    .build();

// ایجاد یک کانکشن با سرور سیگنال ار
var chatConnection = new signalR.HubConnectionBuilder()
    .withUrl('/chatHub')
    .build();
supportConnection.start();
chatConnection.start();

//#endregion
//******************************************* */
//#region UserConnected
supportConnection.on("UserConnected", function (userId) {
   
    var client = _Clients.find(x => x.id == userId);  
    $(`#userRightSidebar-${client.id}`).remove();
    client.isOnline = true;
   
    AddPrependClient(client);
});
supportConnection.on("disableOnlineUser", function (userId) {
    var client = _Clients.find(x => x.id == userId);
    $(`#userRightSidebar-${client.id}`).remove();
    client.isOnline = false;
    AddAppendClient(client);
});

//#endregion
//******************************************* */
//#region Clients
supportConnection.on('GetClientsForAdmin', loadClientsForAdmin);
chatConnection.on('GetClientsForAdmin', loadClientsForAdmin);

function loadClientsForAdmin(clients) {
   
    if (!clients) return;
    _Clients = clients;
    var clientIds = Object.keys(clients);
    if (!clientIds.length) return;

    clientIds.forEach(function (id) {
        var clientInfo = clients[id];
        if (!clientInfo) return;
        //add user
        newAppendToUserList(clientInfo, 'userList');   

    });

}
//#endregion
//******************************************* */
//#region Single Client
function AddPrependClient(client) {
    if (!client) return;
    newPrependToUserList(client,'userList');
}
function AddAppendClient(client) {
    if (!client) return;
    newAppendToUserList(client, 'userList');
}
//#endregion
//******************************************* */
//#region Show Messages User
function showMessagesSupport(userId) {
    var _client = _Clients.find(x => x.id == userId);  
    if (_client==null) {
        supportConnection.invoke('GetClientById', userId)
            .then((responseClient) => {
                // پردازش نتیجه دریافتی
                newPrependToUserList(responseClient, 'userList');
                _Clients.push(responseClient);
            })
            .catch((error) => {
                // پردازش خطا در صورت بروز آن
                console.error(error);
            });
    }
    $(".chitchat-container").toggleClass("mobile-menu");
    if (activeUserId !== '' &&
        $(`#client-${activeUserId}`) !== null &&
        $(`#client-${activeUserId}`).hasClass('active')) {
        supportConnection.invoke('LeaveGrop', activeUserId);   
        document.getElementById(`client-${activeUserId}`).classList.remove('active');
        document.getElementById(`client-${activeUserId}`).style.pointerEvents = "auto";
    }

    activeUserId = userId;
    //#region  Select User
    supportConnection.invoke('LoadMessages', activeUserId);
    supportConnection.on('getConnectionIds', setConnectionIds);
    function setConnectionIds(userConnectionId, adminUserConnectionId) {

        activeUserConnectionId = userConnectionId;
        activeAdminConnectionId = adminUserConnectionId;

        //#region  Add class active for clients
        document.getElementById(`client-${activeUserId}`).classList.add('active');
        document.getElementById(`client-${activeUserId}`).style.pointerEvents = "none";
        //#endregion
    }
    //#endregion
}

//#endregion
//******************************************* */
//#region  Get Single Message
chatConnection.on('getNewMessage', getMessage);
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
supportConnection.on('getNewMessages', getMessages);
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
}
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
    //$(".messages").animate({ scrollTop: $(document).height() }, "fast");
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

function newAppendToUserList(clientInfo,id) {
    return $(`#${id}`).append(`     
                <li data-to="blank" id="client-${clientInfo['id']}" >
                    <div class="chat-box">
                        <a href="#"  onclick="showMessagesSupport('${clientInfo['id']}')">
                            <div class="profile busy ${clientInfo['isOnline'] == true ? 'busy' : ''}">
                                <img class="bg-img w-75" src="${clientInfo['avatarImage']}" alt="Avatar" />
                            </div>
                            <div class="details">
                                <h5> ${clientInfo['fullName'] != null ? clientInfo['fullName'] : clientInfo['phoneNumber']}</h5>
                            </div>
                            <div class="date-status">
                                   
                                <h6 class="font-danger status"> ${clientInfo['branche'] != null ? clientInfo['branche'] : ''}</h6>
                            </div>
                        </a>
                    </div>                       
                </li>
        `);
}
function newPrependToUserList(clientInfo, id) {
    return $(`#${id}`).prepend(`     
                <li data-to="blank" id="client-${clientInfo['id']}" >
                    <div class="chat-box">
                        <a href="#"  onclick="showMessagesSupport('${clientInfo['id']}')">
                            <div class="profile busy ${clientInfo['isOnline'] == true ? 'busy' : ''}">
                                <img class="bg-img w-75" src="${clientInfo['avatarImage']}" alt="Avatar" />
                            </div>
                            <div class="details">
                                <h5> ${clientInfo['fullName'] != null ? clientInfo['fullName'] : clientInfo['phoneNumber']}</h5>
                            </div>
                            <div class="date-status">
                                   
                                <h6 class="font-danger status"> ${clientInfo['branche'] != null ? clientInfo['branche'] : ''}</h6>
                            </div>
                        </a>
                    </div>                       
                </li>
        `);
}

//#endregion
//******************************************* */
//#region Send Message
function sendMessage(text) {
    supportConnection.invoke('SendNewMessage', activeUserId, text);
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
    if (value != null && value != undefined && value != '' && _Clients) {
        var filteredClients = _Clients.filter(x => x.fullName?.includes(value) ||x.phoneNumber?.includes(value));
        $("#userList li").remove();
        loadClientsSearched(filteredClients);
    }
    else {
        $("#userList li").remove();
        loadClientsForAdmin(_Clients);
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
//******************************************* */
//#region ShowExperts
supportConnection.on('GetExperts',getExperts);
function getExperts(clients)
{
    if (!clients) return;
    _Clients = clients;
    var clientIds = Object.keys(clients);
    if (!clientIds.length) return;

    clientIds.forEach(function (id) {
        var clientInfo = clients[id];
        if (!clientInfo) return;
       
        // Add user   
        newAppendToUserList(clientInfo,'experts-list');

    });
}

//#endregion
//******************************************* */
//#region ShowCustomers
supportConnection.on('GetCustomers',getCustomers);
function getCustomers(clients)
{
    if (!clients) return;
    _Clients = clients;
    var clientIds = Object.keys(clients);
    if (!clientIds.length) return;

    clientIds.forEach(function (id) {
        var clientInfo = clients[id];
        if (!clientInfo) return;

        // Add user     
        newAppendToUserList(clientInfo, 'customers-list');
    });
}

//#endregion