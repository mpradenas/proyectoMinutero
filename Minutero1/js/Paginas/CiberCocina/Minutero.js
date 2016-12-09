$(document).ready(function() {
			
		    pageSetUp();
			

		    "use strict";
			
		    var date = new Date();
		    var d = date.getDate();
		    var m = date.getMonth();
		    var y = date.getFullYear();
			
		    var hdr = {
		        left: 'title',
		        center: 'month,agendaWeek,agendaDay',
		        right: 'prev,today,next'
		    };
			
		    var initDrag = function (e) {
		        // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
		        // it doesn't need to have a start or end
			
		        var eventObject = {
		           
		            title: $.trim(e.children().text()), // use the element's text as the event title
		            description: $.trim(e.children('span').attr('data-description')),
		            icon: $.trim(e.children('span').attr('data-icon')),
		            className: $.trim(e.children('span').attr('class')) // use the element's children as the event class
		        };
		        // store the Event Object in the DOM element so we can get to it later
		        e.data('eventObject', eventObject);
			
		        // make the event draggable using jQuery UI
		        e.draggable({
		            zIndex: 999,
		            revert: true, // will cause the event to go back to its
		            revertDuration: 0 //  original position after the drag
		        });
		    };
			
		    var addEvent = function ( title, priority, description, icon) {
		        //idElemento = idElemento.length === 0 ? "no hay id" : idElemento;
		        title = title.length === 0 ? "Untitled Event" : title;
		        description = description.length === 0 ? "No Description" : description;
		        icon = icon.length === 0 ? " " : icon;
		        priority = priority.length === 0 ? "label label-default" : priority;

		        var html = $('<li><span class="' + priority + '" data-description="' + description + '" data-icon="' +
                    icon + '"><i class="fa fa-trash-o"></i></button>'+ title +'</span></li>').prependTo('ul#external-events').hide().fadeIn();
		        //planeo crear un método que elimine el posible plato errado//

		        $("#event-container").effect("highlight", 800);
			
		        initDrag(html);
		    };
			
		    /* initialize the external events
             -----------------------------------------------------------------*/
			
		    $('#external-events > li').each(function () {
		        initDrag($(this));
		    });
			
		    $('#add-event').click(function () {
		        
		        //idElemento=parseInt(idElemento)+1;
                Title = "Menú";
		        if ($('#pPrincipal').val() !=null)
		        {
		            description = $('#pPrincipal option:selected').text();
		        }
		        else if ($('#idPAcomp').val() != null)
		        {

		            description = $('#idPAcomp option:selected').text();
                
		        }
		        else if ($('#idBebestibles').val() != null)
		        {

		            description = $('#idBebestibles option:selected').text();

		        }
		        else if ($('#idPostre').val() != null) {

		            description = $('#idPostre option:selected').text();

		        }
		        priority = $('input:radio[name=priority]:checked').val(),
                icon = $('input:radio[name=iconselect]:checked').val();
			
		        addEvent(Title, priority, description, icon);

		        $('#pPrincipal').prop("disabled", false);
                $('#idPAcomp').prop("disabled", false);
		        $('#idBebestibles').prop("disabled", false);
		        $('#idPostre').prop("disabled", false);

		    });
			
		    /* initialize the calendar
             -----------------------------------------------------------------*/
	

		    $('#calendar').fullCalendar({
			
		        header: hdr,
		        buttonText: {
		            prev: '<i class="fa fa-chevron-left"></i>',
		            next: '<i class="fa fa-chevron-right"></i>'
		        },
			
		        editable: true,
		        droppable: true, // this allows things to be dropped onto the calendar !!!
		        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
		        monthNameShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
		        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
		        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
		        drop: function (date, allDay) { // this function is called when something is dropped
			
		            // retrieve the dropped element's stored Event Object
		            var originalEventObject = $(this).data('eventObject');
			
		            // we need to copy it, so that multiple events don't have a reference to the same object
		            var copiedEventObject = $.extend({}, originalEventObject);
			
		            // assign it the date that was reported
		            copiedEventObject.start = date;
		            copiedEventObject.allDay = allDay;
			
		            // render the event on the calendar
		            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
		            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
			
		            // is the "remove after drop" checkbox checked?
		            if ($('#drop-remove').is(':checked')) {
		                // if so, remove the element from the "Draggable Events" list
		                $(this).remove();
		            }
			
		        },
			
		        select: function (start, end, allDay) {
		            var title = prompt('Event Title:');
		            if (title) {
		                calendar.fullCalendar('renderEvent', {
		                    id: shift_id,
                            title: title,
		                    start: start,
		                    end: end,
		                    allDay: allDay
		                }, true // make the event "stick"
                        );
		            }
		            calendar.fullCalendar('unselect');
		        },
		      
			
		        events: [
                   ],
			
		        eventRender: function (event, element, icon) {
		            if (!event.description == "") {
		                element.find('.fc-event-title').append("<br/><span class='ultra-light'>" + event.description +
                            "</span>");
		            }
		            if (!event.icon == "") {
		                element.find('.fc-event-title').append("<i class='air air-top-right fa " + event.icon +
                            " '></i>");
		            }
		        },
		        eventClick: function (calEvent, jsEvent, view) {
		            var event_ide = calEvent._id;
		            $('#calendar').fullCalendar('removeEvents',event_ide);
		    },
			
		        windowResize: function (event, ui) {
		            $('#calendar').fullCalendar('render');
		        }
		    });
			
		    /* hide default buttons */
		    $('.fc-header-right, .fc-header-center').hide();

			
		    $('#calendar-buttons #btn-prev').click(function () {
		        $('.fc-button-prev').click();
		        return false;
		    });
				
		    $('#calendar-buttons #btn-next').click(function () {
		        $('.fc-button-next').click();
		        return false;
		    });
				
		    $('#calendar-buttons #btn-today').click(function () {
		        $('.fc-button-today').click();
		        return false;
		    });
				
		    $('#mt').click(function () {
		        $('#calendar').fullCalendar('changeView', 'month');
		    });
				
		   /* $('#ag').click(function () {
		        $('#calendar').fullCalendar('changeView', 'agendaWeek');
		    });
				
		    $('#td').click(function () {
		        $('#calendar').fullCalendar('changeView', 'agendaDay');
		    });			*/
		
})

function ejec1()
{
    $('#idBebestibles').val(null);
    $('#idPAcomp').val(null);
    $('#idPostre').val(null);

    $('#idBebestibles').prop("disabled", true);
    $('#idPAcomp').prop("disabled", true);
    $('#idPostre').prop("disabled", true);

}
function ejec2()
{
    $('#idBebestibles').val(null);
    $('#pPrincipal').val(null);
    $('#idPostre').val(null);

    $('#idBebestibles').prop("disabled", true);
    $('#pPrincipal').prop("disabled", true);
    $('#idPostre').prop("disabled", true);


}
function ejec3()
{
    $('#idPAcomp').val(null);
    $('#pPrincipal').val(null);
    $('#idPostre').val(null);

    $('#idPAcomp').prop("disabled", true);
    $('#pPrincipal').prop("disabled", true);
    $('#idPostre').prop("disabled", true);


}
function ejec4()
{
    $('#idPAcomp').val(null);
    $('#pPrincipal').val(null);
    $('#idBebestibles').val(null);

    $('#idPAcomp').prop("disabled", true);
    $('#pPrincipal').prop("disabled", true);
    $('#idBebestibles').prop("disabled", true);
}

function CrearImagen() {
    if ($('.fc-view-month').has('.fc-event').length === 0) {
        alert("El calendario no tiene platos o bebestibles ingresados");
    } else {

        html2canvas($("#todoElCalendario"), {
            onrendered: function (canvas) {
                var miImagen = canvas.toDataURL("image/png");
                //window.open(miImagen);
                window.document.close();
                window.focus();
                miImagen = miImagen.replace('data:image/png;base64,', '');

                //window.print();
                //window.close();

                var fd = new FormData();

                fd.append("action", "guardaImagen");
                fd.append("IdUsuario", parseInt($("#idUsuario").val()));
                fd.append("imagenCalendario", miImagen);
                $.ajax({
                    url: "Minutero.aspx",
                    type: "POST",
                    data: fd,
                    processData: false,
                    contentType: false,
                    success: function (response) {

                        response = response.split("//");

                        alert(response[2]);
                        location.href = "/Paginas/CiberCocina/Minutero.aspx";
                    },
                    error: function (jqXHR, textStatus, errorMessage) {
                        alert("Error al subir el archivo"); // Optional
                    }
                });



            }

        })
    }
}