

function AddClass(Element, Class) {
    var Classes = Element.className;
    if (Classes.search(Class) == -1) {
        Element.className = Classes.concat((Classes.length >= 1 ? " " : "") + Class);
    }
}


function RemoveClass(Element, Class) {
    var Classes = Element.className;
    if (Classes.search(Class) != -1) {
        Element.className = Classes.replace(Class, "");
    }
}


function HasClass(Element, Class) {
    var Classes = Element.className;
    return (Classes.search(Class) == -1 ? false : true);
}


function RemoveAllClasses(Element) {
    Element.className = "";
}


function RemoveElement(Element) {
    RemoveAllChildren(Element);
    Element.parentNode.removeChild(Element);
}


function RemoveAllChildren(Element) {
    if (Element) {
        while (Element.hasChildNodes()) { Element.removeChild(Element.lastChild) };
    }
}

function RemoveAllChildrenButFirst(Element) {
    if (Element) {
        while (Element.hasChildNodes() && Element.childNodes.length > 2) { Element.removeChild(Element.lastChild) };
    }
}

function GetRadioGroupValue(radioName) {
    var allRadiosForName = document.getElementsByName(radioName);

    for (x = 0; x < allRadiosForName.length; x++) {
        if (allRadiosForName[x].checked) {
            return allRadiosForName[x].value;
        }
    }
    return "";
}


function HideOthers(newClassName){
    var bodyElement = document.getElementById("Body");
    var className = "ShowHeaderNotifications";
    if (newClassName != className && HasClass(bodyElement, className)) {
        RemoveClass(bodyElement, className);
    }

    var className = "ShowHeaderLogin";
    if (newClassName != className && HasClass(bodyElement, className)) {
        RemoveClass(bodyElement, className);
    }

    var className = "ShowHeaderUserInfo";
    if (newClassName != className && HasClass(bodyElement, className)) {
        RemoveClass(bodyElement, className);
    }
}


function NotificationsToggle() {
    HideOthers("ShowHeaderNotifications");
    var bodyElement = document.getElementById("Body");
    var className = "ShowHeaderNotifications";
    if(HasClass(bodyElement, className)){
        RemoveClass(bodyElement, className);
    }else{
        AddClass(bodyElement, className);
    }
}


function LoginToggle() {
    HideOthers("ShowHeaderLogin");
    var bodyElement = document.getElementById("Body");
    var className = "ShowHeaderLogin";
    if (HasClass(bodyElement, className)){
        RemoveClass(bodyElement, className);
    }else{
        AddClass(bodyElement, className);
    }
}


function UserInfoToggle() {
    HideOthers("ShowHeaderUserInfo");
    var bodyElement = document.getElementById("Body");
    var className = "ShowHeaderUserInfo";
    if (HasClass(bodyElement, className)) {
        RemoveClass(bodyElement, className);
    } else {
        AddClass(bodyElement, className);
    }
}


(function Load(){
    try {
        var notificationsButton = document.getElementById("NotificationsButton");
        notificationsButton.addEventListener("click", NotificationsToggle, false);
    } catch (error) {
        console.log("notificationsButton failed");
    }

    try {
        var loginButton = document.getElementById("LoginButton");
        loginButton.addEventListener("click", LoginToggle, false);
    } catch (error) {
        console.log("loginButton failed");
    }


    try {
        var userInfoButton = document.getElementById("UserInfoButton");
        userInfoButton.addEventListener("click", UserInfoToggle, false);
    } catch (error) {
        console.log("userInfo failed");
    }
})();













//; (function ($, window, undefined) {
//    'use strict';

//    var $doc = $(document),
//        Modernizr = window.Modernizr;

//    $(document).ready(function () {
//        $.fn.foundationAlerts ? $doc.foundationAlerts() : null;
//        $.fn.foundationButtons ? $doc.foundationButtons() : null;
//        $.fn.foundationAccordion ? $doc.foundationAccordion() : null;
//        $.fn.foundationNavigation ? $doc.foundationNavigation() : null;
//        $.fn.foundationTopBar ? $doc.foundationTopBar() : null;
//        $.fn.foundationCustomForms ? $doc.foundationCustomForms() : null;
//        $.fn.foundationMediaQueryViewer ? $doc.foundationMediaQueryViewer() : null;
//        $.fn.foundationTabs ? $doc.foundationTabs({ callback: $.foundation.customForms.appendCustomMarkup }) : null;
//        $.fn.foundationTooltips ? $doc.foundationTooltips() : null;
//        $.fn.foundationMagellan ? $doc.foundationMagellan() : null;
//        $.fn.foundationClearing ? $doc.foundationClearing() : null;

//        //Disabled for MVC. This plugin does not work with jquery.validate.js
//        //https://github.com/zurb/foundation/issues/747
//        //$('input, textarea').placeholder();

//    });

//    // UNCOMMENT THE LINE YOU WANT BELOW IF YOU WANT IE8 SUPPORT AND ARE USING .block-grids
//    // $('.block-grid.two-up>li:nth-child(2n+1)').css({clear: 'both'});
//    // $('.block-grid.three-up>li:nth-child(3n+1)').css({clear: 'both'});
//    // $('.block-grid.four-up>li:nth-child(4n+1)').css({clear: 'both'});
//    // $('.block-grid.five-up>li:nth-child(5n+1)').css({clear: 'both'});

//    // Hide address bar on mobile devices (except if #hash present, so we don't mess up deep linking).
//    if (Modernizr.touch && !window.location.hash) {
//        $(window).load(function () {
//            setTimeout(function () {
//                window.scrollTo(0, 1);
//            }, 0);
//        });
//    }

//})(jQuery, this);
