AOS.init();

let menu = document.getElementById('menu');
let menu_bar=document.getElementById('menu-bar');
menu_bar.addEventListener('click',function(){/*Escuchador de eventos.Cuando escuche el evento click
                                                va a ejecutar la función().*/
    menu.classList.toggle('menu-toggle')
});