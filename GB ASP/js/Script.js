

var popUp;

function SetControlValue(controlID, newDate, isPostBack) {

    popUp.close();

    //document.forms[0]["textBox"].value=0;

    //document.getElementById('<%= textBox.ClientID%>').value=0;

    document.forms[0][controlID].value = newDate;

    // __doPostBack(controlID,'');

}

function OpenPopupPage(pageUrl, controlID, isPostBack) {

    popUp = window.open(pageUrl + '?controlID=' + controlID + '&isPostBack=' + isPostBack, 'popupcal', 'width=250,height=330,left=200,top=250');

}