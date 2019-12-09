
function openMenu(evt, menuName) {
  var mT, tabmenucontent, tablinksmenu;
  tabmenucontent = document.getElementsByClassName("tabmenucontent");
  for (mT = 0; mT < tabmenucontent.length; mT++) {
    tabmenucontent[mT].style.display = "none";
  }
  tablinksmenu = document.getElementsByClassName("tablinksmenu");
  for (mT = 0; mT < tablinksmenu.length; mT++) {
    tablinksmenu[mT].className = tablinksmenu[mT].className.replace(" active", "");
  }
    document.getElementById(menuName).style.display = "block";
  evt.currentTarget.className += " active";
}
