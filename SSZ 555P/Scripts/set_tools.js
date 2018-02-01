$(document).ready(function () {

    
    $(".table5").ready(function () {
        var heigthTab5 = $(document).height();
        if (heigthTab5>530)
        $(".table5").height(heigthTab5 - 230);

    });



        var fixHelper = function (e, ui) {

            ui.children().each(function () {

                $(this).width($(this).width());

            });
           
            return ui;

        };

        var tab5Change = function () {

            calcPosMT();

        };

        var tab6Change = function () {

            calcPosMT6();

        };

        var tab7Change = function () {

            calcPosMT7();

        };

        var tab8Change = function () {

            calcPosMT8();

        };

        var tab9Change = function () {

            calcPosMT9();

        };

        var tab10Change = function () {

            calcPosMT10();

        };

        var tab11Change = function () {

            calcPosMT11();

        };

        $("input #item_width").keydown(function(event) {
            // Разрешаем: backspace, delete, tab и escape
            if ( event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || 
                // Разрешаем: Ctrl+A
                (event.keyCode == 65 && event.ctrlKey === true) || 
                // Разрешаем: home, end, влево, вправо
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                // Ничего не делаем
                return;
            }
            else {
                // Обеждаемся, что это цифра, и останавливаем событие keypress
                if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105 )) {
                    event.preventDefault(); 
                }   
            }
        });

        $("#table5 tbody").sortable({

            helper: fixHelper,
            stop: tab5Change,
            distance:3
            
        }).disableSelection();

        $("#table6 tbody").sortable({

            helper: fixHelper,
            stop: tab6Change,
            distance: 3

        }).disableSelection();
      
        $("#table7 tbody").sortable({

            helper: fixHelper,
            stop: tab7Change,
            distance: 3

        }).disableSelection();

        $("#table8 tbody").sortable({

            helper: fixHelper,
            stop: tab8Change,
            distance: 3

        }).disableSelection();

        $("#table9 tbody").sortable({

            helper: fixHelper,
            stop: tab9Change,
            distance: 3

        }).disableSelection();

        $("#table10 tbody").sortable({

            helper: fixHelper,
            stop: tab10Change,
            distance: 3

        }).disableSelection();

        $("#table11 tbody").sortable({

            helper: fixHelper,
            stop: tab11Change,
            distance: 3

        }).disableSelection();


        $(".table5 td").on("mouseenter mouseleave", function () {
            $(this).parent('tr').toggleClass('check_td');
            //      $(this).toggleClass('check_td');
            /* var ind = $(this).index();
             $('tr').each(function () {
                 $('td:eq(' + ind + ')', this).toggleClass('checkT');
             });*/
        });

        $(".table5 tr").click(function () {
            $('tr').each(function () {
                $(this).removeClass('check_din');
            });
            $(this).addClass('check_din');
        });
       
        var stop=false;

        $("#save5").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table5');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return5").css("background-color", "#999");
            var interval = setInterval(function () {
                stop = true;
                
                var position = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 5 };
                   
                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval);
                    $(".ButAct #return5").css("background-color", "#0051a3");
                    stop = false;
                };
            }, 30)
            
          

        });

        $("#return5").click(function () {
            if (!stop) {
                //Откатываем значение таблицы
                var table = document.getElementById('table5');
                // удаляем позиции таблицы

                $('#table5 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 5 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table5').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });
    /************************************************************************************/
        var stop6 = false;

        $("#save6").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table6');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return6").css("background-color", "#999");
            var interval6 = setInterval(function () {
                stop6 = true;

                var position = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 6 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval6);
                    $(".ButAct #return6").css("background-color", "#0051a3");
                    stop6 = false;
                };
            }, 30)



        });

        $("#return6").click(function () {
            if (!stop6) {
                //Откатываем значение таблицы
                var table = document.getElementById('table6');
                // удаляем позиции таблицы

                $('#table6 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 6 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table6').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });
    /******************************************************************************/
        var stop7 = false;
        $("#save7").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table7');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return7").css("background-color", "#999");
            var interval7 = setInterval(function () {
                stop6 = true;

                var position = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 7 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval7);
                    $(".ButAct #return7").css("background-color", "#0051a3");
                    stop7 = false;
                };
            }, 30)



        });

        $("#return7").click(function () {
            if (!stop7) {
                //Откатываем значение таблицы
                var table = document.getElementById('table7');
                // удаляем позиции таблицы

                $('#table7 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 7 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table7').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });
    /******************************************************************************************/
        var stop8 = false;
        $("#save8").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table8');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return8").css("background-color", "#999");
            var interval8 = setInterval(function () {
                stop8 = true;

                var position = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 8 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval8);
                    $(".ButAct #return8").css("background-color", "#0051a3");
                    stop8 = false;
                };
            }, 30)



        });

        $("#return8").click(function () {
            if (!stop8) {
                //Откатываем значение таблицы
                var table = document.getElementById('table8');
                // удаляем позиции таблицы

                $('#table8 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 8 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table8').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });

    /******************************************************************************************/
    /******************************************************************************************/
        var stop10 = false;
        $("#save10").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table10');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return10").css("background-color", "#999");
            var interval10 = setInterval(function () {
                stop10 = true;

                var position = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 10 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval10);
                    $(".ButAct #return10").css("background-color", "#0051a3");
                    stop10 = false;
                };
            }, 30)



        });

        $("#return10").click(function () {
            if (!stop10) {
                //Откатываем значение таблицы
                var table = document.getElementById('table10');
                // удаляем позиции таблицы

                $('#table10 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 10 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table10').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });

    /******************************************************************************************/

    /******************************************************************************************/
        var stop11 = false;
        $("#save11").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table11');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return11").css("background-color", "#999");
            var interval11 = setInterval(function () {
                stop11 = true;

                var position = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 11 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval11);
                    $(".ButAct #return11").css("background-color", "#0051a3");
                    stop11 = false;
                };
            }, 30)



        });

        $("#return11").click(function () {
            if (!stop11) {
                //Откатываем значение таблицы
                var table = document.getElementById('table11');
                // удаляем позиции таблицы

                $('#table11 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 11 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table11').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });

    /******************************************************************************************/

        var stop9 = false;
        $("#save9").click(function () {
            //получаем по строчно строки таблицы
            var table = document.getElementById('table9');
            var i = 1;
            var pauseI = true;
            $(".ButAct #return9").css("background-color", "#999");
            var interval9 = setInterval(function () {
                stop9 = true;

                var position = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(1)').text();
                var name = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(2)').text();
                var description = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(3)').text();
                var width1 = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(4)').find('input#item_width').val();
                var fontsize1 = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(5)').find('input#item_fontSize').val();
                var vis1 = $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(6)').find('input#item_visibleCol').is(':checked');
                var z = { Position: position, Name: name, Description: description, Width1: width1, Fontsize1: fontsize1, Vis1: vis1, Ind: i };
                if (pauseI) {
                    pauseI = false;
                    $.post("/Setting/FormGrid", z, function (res1) {
                        pauseI = true;
                        i++;
                    }, "json")
                }
                if (i == table.rows.length) {
                    var z = { TypeGrid: 9 };

                    $.post("/Setting/SaveGrid", z, "json")
                    clearInterval(interval9);
                    $(".ButAct #return9").css("background-color", "#0051a3");
                    stop9 = false;
                };
            }, 30)



        });

        $("#return9").click(function () {
            if (!stop9) {
                //Откатываем значение таблицы
                var table = document.getElementById('table9');
                // удаляем позиции таблицы

                $('#table9 tbody tr').remove();
                //Перезаполняем таблицу
                var z = { TypeGrid: 9 };
                var check = '';
                $.post("/Setting/ReturnGrid", z, function (res1) {
                    if (res1.isAdded) {
                        for (var i = 0; i < res1.sp.length; i++) {
                            if (res1.sp[i].visibleCol) check = "checked='checked'";
                            else check = "";
                            $('#table9').append('<tr><td>' + res1.sp[i].position + '</td><td>' + res1.sp[i].Name + '</td><td>' + res1.sp[i].Description + '</td><td style="padding:0px !important;" ><input id="item_width" maxlength="3" name="item.width" type="text" value="' + res1.sp[i].width + '" /></td><td style="padding:0px !important;" > <input id="item_fontSize" maxlength="2" name="item.fontSize" type="text" value="' + res1.sp[i].fontSize + '" /></td><td ><input ' + check + ' id="item_visibleCol" name="item.visibleCol" type="checkbox" value="' + res1.sp[i].visibleCol + '" /></td></tr>');
                        }
                    }

                }, "json")
            }
        });

});

$(window).resize(function () {
    var heigthTab5 = $(document).height();
    if (heigthTab5 > 530)
        $(".table5").height(heigthTab5 - 230);
});


function calcPosMT()
{
    var table = document.getElementById('table5');
    for (i = 0 ; i < table.rows.length ; i++)
    {
        $('#table5 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT6() {
    var table = document.getElementById('table6');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table6 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT7() {
    var table = document.getElementById('table7');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table7 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT8() {
    var table = document.getElementById('table8');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table8 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT9() {
    var table = document.getElementById('table9');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table9 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT10() {
    var table = document.getElementById('table10');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table10 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}

function calcPosMT11() {
    var table = document.getElementById('table11');
    for (i = 0 ; i < table.rows.length ; i++) {
        $('#table11 tr:nth-child(' + i + ')').find('td:nth-child(1)').html(i);
    }
}