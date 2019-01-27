
debugger;
var myhub = $.connection.myhubs;

$.connection.hub.start().done(function () {
});

myhub.client.test = function (friendid) {
    _friendid = friendid;
    $.ajax({
        url: '/Home/GetMessages',
        method: 'POST',
        data: { FriendId: _friendid },
        //success: function (data) {
        success: function (data) {
            debugger;
            $('#Chatting').html(data);
            $('.Chatwith').text(_friendName);
            $(".msg_card_body").scrollTop(10000000000000000);
        },
        error: function () {
            alert("Something went Worng.");
        }
    });
};