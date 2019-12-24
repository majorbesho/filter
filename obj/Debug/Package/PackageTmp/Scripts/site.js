$("#login-button").click(function(event){
    event.preventDefault();

$('form').fadeOut(500);
$('#wrapper').addId('form-success');
});
setTimeout(function(){ 
    document.getElementById("loading").classList.add("none");
 }, 3000);
/*Satrt tabs*/

function openMenu(evt, cityName) {
    var mT, tabmenucontent, tablinksmenu;
    tabmenucontent = document.getElementsByClassName("tabmenucontent");
    for (mT = 0; mT < tabmenucontent.length; mT++) {
        tabmenucontent[mT].style.display = "none";
    }
    tablinksmenu = document.getElementsByClassName("tablinksmenu");
    for (mT = 0; mT < tablinksmenu.length; mT++) {
        tablinksmenu[mT].className = tablinksmenu[mT].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

/*End tabs*/