var Obj;// id позиции
var Asszl1;//счетчик
var Zakaz;
var Oper;
var StatusW;
var Status;
var currentCustomerID;
var pageID;
var Asszl;
var TpOper;
var posV = 0;
var ActBut;
var Sernp;
var BreakOper = true;

$(document).ready(function () {





    $("#menusetTable").click(function () {

        GetMenuSet(1);
    });

    $("#menusetCommon").click(function () {
        GetMenuSet(2);
    });


    function GetMenuSet(index) {
        if (index == 1) {
            $("#menusetTable").css({ "color": "#fff", "font-weight": "bold" });
            $("#menusetCommon").css({ "color": "#bbb", "font-weight": "400" });

            $("#tabsetg").css({ "visibility": "visible", "display": "block" });
            $("#commonset").css({ "visibility": "hidden", "display": "none" });
        }
        else if (index == 2) {
            $("#menusetTable").css({ "color": "#bbb", "font-weight": "400" });
            $("#menusetCommon").css({ "color": "#fff", "font-weight": "bold" });
            $("#tabsetg").css({ "visibility": "hidden", "display": "none" });
            $("#commonset").css({ "visibility": "visible", "display": "block" });
        }



    }

    $("#GridView td.dxgvHeader_DevEx.headerTab:first").text("ТД");




    $("[data-title]").mousemove(function (eventObject) {
        var _self = $(this);
        $data_tooltip = $(this).attr("data-title");
        $("#tooltip").text($data_tooltip)
                     .css({
                         "top": _self.offset().top - 25,
                         "left": _self.offset().left + 5
                     })
                     .show();

    }).mouseout(function () {

        $("#tooltip").hide()
                     .text("")
                     .css({
                         "top": 0,
                         "left": 0
                     });
    });


    // плдсветка кнопок

    $("#butSt").mouseover(function () {
        if (ActBut != "1" && ActBut != "5")
            $(this).css("box-shadow", "0 0 5px 1px #00cc00");
    }).mouseout(function () {
        if (ActBut != "1")
            $(this).css("box-shadow", "none");
    });


    $("#butP").mouseover(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "0 0 5px 2px #FFA500");
    }).mouseout(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "none");
    });

    $("#butStop").mouseover(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "0 0 5px 2px #FF0000");
    }).mouseout(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "none");
    });

    $("#butClose").mouseover(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "0 0 5px 2px #A600A6");
    }).mouseout(function () {
        if (ActBut == "1")
            $(this).css("box-shadow", "none");
    });
    // подсветка кнопок

    //выбор периода для расчетного листка
    $("#AppTotalList").click(function () {
        //проверяем занчение даты
        var val = $("input[name='DateEdit']").val();
        if (val == "") {
            showMessegaError("Укажите дату выгрузки расчетного листка");
        }
        else {
            var z = { DateR: val };
            $.post("/Dialog/GetTotalList", z, function (res) {
                if (res.isAdded) {
                    $("a#urlTotalList").attr("href", res.UrlAdress);
                    GridViewTotalList.Refresh();
                }
                else { }
            }, "json");

        }
    });


    // вызов окна предупреждения при нажатие кнопки старт
    $("#butSt").click(function () {
        if (BreakOper) {

            if (ActBut == "0") {
                $("#textW").html("<strong>Начать операцию " + Oper + " с номером заказа " + Zakaz + " ?</strong>");
                StatusW = 1;
                $(".Waring").css({ "color": "white", "background-color": "rgb(40, 154, 70)" });
                PopupCaution.Show();
            }
            else if (ActBut == "2") {
                var z = { obj: Obj, allzt: Asszl1, act: "CN1", step: "1" };
                BreakOper = false;
                //передаем наши параметры контролеру
                $.post("/Home/StatrtStatus", z, function (res) {
                    if (res.isAdded) {
                        showMessega(res);
                        BreakOper = true;
                    }
                    else {
                        var z1 = { obj: Obj, allzt: Asszl1, act: "CN1", step: "2" };
                        $.post("/Home/StatrtStatus", z1, function (res1) {
                            if (res1.isAdded) {
                                showMessega(res1);
                                if (res1.type == "I") {
                                    rereshGridTwo("1", 0, 0);
                                }
                            }
                            BreakOper = true;
                        }, "json")
                    }
                }, "json")
            }

        }
    });



    //вызов окна описания операции
    $("#butdoc").click(function () {
        PopupTableDetails.PerformCallback();
        PopupTableDetails.Show();
    });


    $("#Oteil_B-1").click(function () { });


    // нажатие кнопки ок в окне предупреждение
    $("#butWok").click(function () {
        if (StatusW = 1) // если нажата была кнопка старт( начало операции)
        {


            var z = { obj: Obj, allzt: Asszl1, act: "S1", step: "1" };
            //передаем наши параметры контролеру
            PopupCaution.Hide();
            $.post("/Home/StatrtStatus", z, function (res) {
                if (res.isAdded) {
                    showMessega(res);
                }
                else {
                    var z1 = { obj: Obj, allzt: Asszl1, act: "S1", step: "2" };
                    $.post("/Home/StatrtStatus", z1, function (res1) {
                        if (res1.isAdded) {
                            if (res1.type == "I") {
                                rereshGridTwo("1", 0, 0);
                            }
                            showMessega(res1);
                        }

                    }, "json")
                }
            }, "json")
            /*  $.ajax({
                  type: "POST",
                  url: "/Home/StatrtStatus",
                  data: JSON.stringify({ obj: Obj, allzt: Asszl1 }),
              contentType: "application/json",
              success: function (res)
              {
                  if (res.isAdded)
                  {
                      PopupRedAlert.Show();
                  }
              }
              });*/
        }
    });

    //нажатие кнопки пауза
    $("#butP").click(function () {
        if (BreakOper) {
            BreakOper = false;
            if (ActBut == "1") {
                var z = { obj: Obj, allzt: Asszl1, act: "P1", step: "1" };
                //передаем наши параметры контролеру
                $.post("/Home/StatrtStatus", z, function (res) {
                    if (res.isAdded) {
                        showMessega(res);
                        BreakOper = true;
                    }
                    else {
                        var z1 = { obj: Obj, allzt: Asszl1, act: "P1", step: "2" };
                        $.post("/Home/StatrtStatus", z1, function (res1) {
                            if (res1.isAdded) {
                                if (res1.type == "I") {
                                    rereshGridTwo("2", 0, 0);
                                }
                                showMessega(res1);
                            }

                        }, "json")
                        BreakOper = true;
                    }
                }, "json")
            }

        }
    });

    //нажатие кнопки стоп
    $("#butStop").click(function () {
        if (BreakOper) {
            BreakOper = false;
            if (ActBut == "1") {
                TpOper = "STOP";
                var z = { obj: Obj, allzt: Asszl1, act: "ST1", step: "1", sernp: Sernp };
                //передаем наши параметры контролеру
                $.post("/Home/StopComplete", z, function (res) {
                    if (res.isAdded) {

                        showMessega(res);
                        BreakOper = true;
                    }
                    else {
                        ConfirmOperationPopup.PerformCallback();
                        $(".confirmTabHeader").html("<strong>Остановка операции " + Oper + " с номером заказа " + Zakaz + "</strong>");
                        if (Zakaz.charAt(0) == '4') {
                            $("tr#braktr").css("display", "none");
                        }
                        else $("tr#braktr").css("display", "none");
                        ConfirmOperationPopup.Show();
                        BreakOper = true;
                    }
                }, "json")
            }

        }
    });



    $("#butClose").click(function () {
        if (BreakOper) {
            BreakOper = false;
            if (ActBut == "1") {
                TpOper = "COMPLETE";
                var z = { obj: Obj, allzt: Asszl1, act: "C1", step: "1", sernp: Sernp };
                //передаем наши параметры контролеру
                $.post("/Home/StopComplete", z, function (res) {
                    if (res.isAdded) {
                        showMessega(res);
                        BreakOper = true;
                    }
                    else {
                        ConfirmOperationPopup.PerformCallback();
                        $(".confirmTabHeader").html("<strong>Закрытие операции " + Oper + " с номером заказа " + Zakaz + "</strong>");
                        if (Zakaz.charAt(0) == '4') {
                            $("#braktr").hide();
                        }
                        else $("#braktr").show();
                        ConfirmOperationPopup.Show();
                        BreakOper = true;
                    }
                }, "json")
            }

        }

    });

    //вызов сообщения о несоотвествии  
    $("#butj").click(function () {
        if (BreakOper) {
            BreakOper = false;
            var z = { obj: Obj, allzt: Asszl1, act: "ALARM", step: "1", message: "", type: "", qmgrp: "", qmcod: "", otgrp: "", oteil: "", coord: "", KolDef: 0, checkP:"" };
            $.post("/Home/ASMessage", z, function (res) {
                if (res.isAdded) {
                    showMessega(res);
                }
                else {
                    PopupMessage.PerformCallback();
                    $(".confirmTabHeader").html("<strong>Сообщение по операции " + Oper + " с номером заказа " + Zakaz + "</strong>");
                    PopupMessage.Show();
                }
            }, "json")
            BreakOper = true;
        }
    });


    $("#butL").click(function () {

        PopupTotalList.Show();
        PopupTotalList.SetWidth(document.documentElement.clientWidth * 0.9);
        PopupTotalList.SetHeight(document.documentElement.clientHeight * 0.9);
        PopupTotalList.UpdatePosition();
        GridViewTotalList.SetHeight(document.documentElement.clientHeight * 0.9 - 70)
    });



});

var isDetailRowExpanded = new Array();

function showMessega(res) {

    $("#err_message").html(res.message);
    if (res.type == "W") {
        //   PopupRedAlertSimple.Show();
        $(".error-windows").css({ "color": "white", "background-color": "#e19104" });
        PopupRedAlertSimple.Show();
    }
    else if (res.type == "E") {
        //  PopupRedAlertSimple.Show();
        $(".error-windows").css({ "color": "white", "background-color": "red" });
        PopupRedAlertSimple.Show();
    }
    else {

        $(".error-windows").css({ "color": "white", "background-color": "rgb(40, 154, 70)" })

        /*setTimeout(function () { PopupRedAlertSimple.Hide(); }, 1000);*/
    };

}




function showMessegaError(res) {
    PopupRedAlertSimple.Show();
    $("#err_message").html(res);
    $(".error-windows").css({ "color": "white", "background-color": "red" });
}

function OnRowClickD(s, e) {
    if (isDetailRowExpanded[e.visibleIndex] != true) {
        s.ExpandDetailRow(e.visibleIndex);
        isDetailRowExpanded[e.visibleIndex] = true;
    }
    else {
        s.CollapseDetailRow(e.visibleIndex);
        isDetailRowExpanded[e.visibleIndex] = false;
    }
}

var IndexRowClickTab1 = 0;

function OnTab1Click(s, e) {
    IndexRowClickTab1 = e.visibleIndexl;
}

//если нажата кнопка ок при остановки операции или закрытию
function ButOk() {
    // 1. проверяем на корректность ввода потвержденного количества

    var product = $("input[name='Lmnga']").val();
    if (!isNumeric(product)) {
        showMessegaError("Укажите правильно количество выходной продукции");
        return;
    }
    // 2. проверяем на корректность ввода брака
    var brak = $("input[name='Xmnga']").val();
    if (!isNumeric(brak)) {
        showMessegaError("Укажите правильно количество брака");
        return;
    }
    // 3. запускаем  второй шаг операции
    var messageW = $("input[name='Ltxa1']").val();
    var product1 = product.replace(',', '.');
    var brak1 = brak.replace(',', '.');
    var z = { prod: product1, br: brak1, step: "2", mess: messageW, Operate: TpOper };
    //передаем наши параметры контролеру
    $.post("/Home/StopCompleteTwo", z, function (res) {
        if (res.isAdded) {
            if (res.type == "I") {
                ConfirmOperationPopup.Hide();
                if (TpOper == "COMPLETE")
                    rereshGridTwo("4", "1");
                else rereshGridTwo("3", "0");

            }
            showMessega(res);
        }
        else { ConfirmOperationPopup.Hide(); }
    }, "json")
}
//отправка сообщения
var rereshBool = false;
function rereshGrid() {
    $.post("/Home/GridViewPartialViewUpdate3");
    posV = GridView.GetVerticalScrollPosition();
    rereshBool = true;
    GridView.Refresh();
}

function GEndCallback(s, e) {
    if (rereshBool == true) {
        s.SetVerticalScrollPosition(posV);
        rereshBool = false;

    }


}



function rereshGridTwo(str, opc) {
    // запоминаем позицию скролла
    var positionScroll = GridView.GetVerticalScrollPosition();
    if (str == "1") { ActBut = "1"; }
    else if (str == "2" || str == "3") { ActBut = "2"; }
    else if (str == "4") { ActBut = "5"; }
    else ActBut = "0";
    var z = { stat: str, obj: Obj, allzt: Asszl1, opci: opc, ActB: ActBut };
    /*  $.post("/Home/GridViewPartialViewUpdate",z, function (res) {
          var GetIndexFocus = GridView.GetFocusedRowIndex();
          // замена значения ячеек
          GridView.batchEditApi.SetCellValue(GetIndexFocus, "xmnga", res.brakC);
          GridView.batchEditApi.SetCellValue(GetIndexFocus, "lmnga", res.prodC);
          GridView.batchEditApi.SetCellValue(GetIndexFocus, "usttxt", str);
          GridView.GetRow(GetIndexFocus+3).style.backgroundColor = "red";
        //  GridView.batchEditApi.C
      }, "json");*/
    $.post("/Home/GridViewPartialViewUpdate", z);
    var GetIndexFocus = GridView.GetFocusedRowIndex();
    setTimeout(function () { GridView.CollapseDetailRow(GetIndexFocus) }, 1500);
    Status = str;


    StatusFun(ActBut);
    $("#butSt").css("box-shadow", "none");
    $("#butP").css("box-shadow", "none");
    $("#butStop").css("box-shadow", "none");
    $("#butClose").css("box-shadow", "none");
    //   GridView.SetVerticalScrollPosition(positionScroll);
}
var RowCount = 0;
var SetRowRefresh = 0;
function onlineRefresh() {

    var z = {};
    $.post("/Home/GridViewPartialViewUpdate3", z, function (res) {
        if (res.isAdded) {
            RowCount = res.RowCount;
            SetRowRefresh = 0;
            setTimeout(function () { RowRefresh() }, 200);
        }
    }, "json")

}


function RowRefresh() {
    SetRowRefresh++;
    GridView.CollapseDetailRow(SetRowRefresh);
    if (SetRowRefresh < RowCount) {
        setTimeout(function () { RowRefresh() }, 200);
    }

}


function SentMessage() {
    var Getselectpos = $("#selectedNodeIDsMainPage").val();

    var kolDef = $("input[name='Rkmng']").val();
    if (!isNumeric(kolDef)) {
        showMessegaError("Укажите правильно количество выходной продукции");
        return;
    }
    //1 считываем номер сообщения

    //2 считываем тип сообщения
    //   var TypeMessage = $("input[name='Qmart']").val();
    //3 считываем текст сообщения
    // var messageW = $("input[name='Text']").val();
    var QmgrpS = Qmgrp.GetValue();
    var QmcodS = Qmcod.GetValue();
    var OtgrpS = Otgrp.GetValue();
    var OteilS = Oteil.GetValue();
    // var FegrpS = "";// Fegrp.GetValue();
    // var FecodS = "";// Fecod.GetValue();
    var CoordS = Coord.GetValue();

    if (QmgrpS == "Выберите группу") QmgrpS = "";
    if (OtgrpS == "Выберите группу") OtgrpS = "";
    //   if (FegrpS == "Выберите группу") FegrpS = "";
    if (CoordS == "Выберите коорд.") CoordS = "";


    if (QmcodS == "Выберите Код") QmcodS = "";
    if (OteilS == "Выберите Код") OteilS = "";
    //  if (FecodS == "Выберите Код") FecodS = "";

    var col 
    var messageW = $("#Text").val();
    if (messageW == "" || messageW == undefined) {
        showMessegaError("Заполните поле описание");
        return;
    }
    
    var z = {
        obj: Obj, allzt: Asszl1, act: "ALARM", step: "2", message: messageW, type: "", qmgrp: QmgrpS, qmcod: QmcodS, otgrp: OtgrpS, oteil: OteilS, coord: CoordS, KolDef: kolDef, checkP: Getselectpos
    };
    $.post("/Home/ASMessage", z, function (res) {
        if (res.isAdded) {
            if (res.type == "I") {
                PopupMessage.Hide();

            }
            showMessega(res);

        }
        else {
            PopupMessage.Hide();
        }
    }, "json")
    rereshGridTwo("0", "1");
}

//получаем значение выделеной строки
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'Objnr;Usttxt;Asszl;Aufnr;Vornr;ActsAlwd1;Sernp;', function (values) {
        Obj = values[0];
        Status = values[1];
        Asszl1 = values[2];
        Zakaz = values[3];
        Oper = values[4];
        ActBut = values[5];
        Sernp = values[6];
        StatusFun(values[5]);
    });

}



//проверка на число
function isNumeric(n) {
    n = n.replace(',', '.');
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function StatusFun(stat) {
    if (stat == "1") {
        $("#butSt").css("background-image", "url(../Content/Images/buttom/startN.png)");
        $("#butP").css("background-image", "url(../Content/Images/buttom/pause.png)");
        $("#butStop").css("background-image", "url(../Content/Images/buttom/stop.png)");
        $("#butClose").css("background-image", "url(../Content/Images/buttom/close.PNG)");
    }
    else if ((stat == "0" || stat == "2")) {
        $("#butSt").css("background-image", "url(../Content/Images/buttom/start.png)");
        $("#butP").css("background-image", "url(../Content/Images/buttom/pauseN.png)");
        $("#butStop").css("background-image", "url(../Content/Images/buttom/stopN.png)");
        $("#butClose").css("background-image", "url(../Content/Images/buttom/closeN.png)");
    }
    else {
        $("#butSt").css("background-image", "url(../Content/Images/buttom/startN.png)");
        $("#butP").css("background-image", "url(../Content/Images/buttom/pauseN.png)");
        $("#butStop").css("background-image", "url(../Content/Images/buttom/stopN.png)");
        $("#butClose").css("background-image", "url(../Content/Images/buttom/closeN.png)");
    }

}

function OnGetRowValues(values) {
    Obj = values[0];
    Asszl1 = values[1];
    Zakaz = values[2];
    Oper = values[3];
    // GridView.Refresh();

}

function OnHyperLinkClick(customerID, asszl1, page) {
    currentCustomerID = customerID;
    pageID = page;
    Asszl = asszl1;
    popup.PerformCallback();
    popup.Show();
}
function OnPopupBeginCallback(s, e) {
    e.customArgs["customerID"] = currentCustomerID;
    e.customArgs["Asszl"] = Asszl;
    e.customArgs["pageID"] = pageID;
}

function OnPopupBeginCallbackOper(s, e) {
    e.customArgs["obj"] = Obj;
    e.customArgs["Asszl"] = Asszl1;

}

function OnConfirmCallbackOper(s, e) {
    e.customArgs["obj"] = Obj;
    e.customArgs["Asszl"] = Asszl1;

}

function OnMessage(s, e) {
    e.customArgs["obj"] = Obj;
    e.customArgs["Asszl"] = Asszl1;
}

//запрет на перевод ячеек в формат редактирования

function Grid_Batch(s, e) {
    e.cancel = true;
}



function onComboBoxQmgrpChanged(s, e) {
    Qmcod.PerformCallback();
}

function onComboBoxOtgrpChanged(s, e) {
    Oteil.PerformCallback();
}

function onComboBoxFegrpChanged(s, e) {
    Fecod.PerformCallback();
}

function Qmcod_beginCallBack(s, e) {
    e.customArgs["Qmgrp1"] = Qmgrp.GetValue();
}

function Oteil_beginCallBack(s, e) {
    e.customArgs["Otgrp1"] = Otgrp.GetValue();
}

function Fecod_beginCallBack(s, e) {
    e.customArgs["Fegrp1"] = Fegrp.GetValue();
}




function RefreshTabAuto() {

    var VertScrollPossition = GridView.GetVerticalScrollPosition;
    var HorScrollPossition = GridView.GetHorticalScrollPosition;
    rereshGrid();
    GridView.VertScrollPossition = VertScrollPossition;
    GridView.HorScrollPossition = HorScrollPossition;
}


var StatusActTab;
/*Перемещение позиции по настроечной таблицы*/
function OnUpButtonClick(s, e) {
    StatusActTab = "Up";
    setTimeout(FocusGridViewByRowIndex, 200);
}
function OnDownButtonClick(s, e) {
    StatusActTab = "Down";
    setTimeout(FocusGridViewByRowIndex, 200);
}
function FocusGridViewByRowIndex() {
    var newFocusedRowIndex = GridViewSetOper.GetFocusedRowIndex();
    GridViewSetOper.PerformCallback({ focusedRowIndex: newFocusedRowIndex, ActionB: StatusActTab });
}

var lastposition = 0;

function FocusGridViewSetOper(s, e) {





    s.GetRowValues(GridViewSetOper.GetFocusedRowIndex(), 'position;width;Name;visibleCol;', function (values) {
        Gposition = values[0];
        Gwidth = values[1];
        GName = values[2];
        Gvisible = values[3];;
    });
    Gvisible = s.batchEditApi.GetCellValue(lastposition, "visibleCol");
    Gwidth = s.batchEditApi.GetCellValue(lastposition, "width");
    var z = { Position: Gposition, Width: Gwidth, NPame: GName, GVisible: Gvisible };
    $.post("/Setting/TempUpdate", z, "json")
    lastposition = GridViewSetOper.GetFocusedRowIndex();
    GridViewSetOper.CollapseDetailRow(lastposition);

}
var Gposition;
var Gwidth;
var GName;
var Gvisible;

function ValidGridViewSetOper(s, e) {
    s.GetRowValues(lastposition, 'position;width;Name;visibleCol;', function (values) {
        Gposition = values[0];
        Gwidth = values[1];
        GName = values[2];
        Gvisible = values[3];;
    });

    Gvisible = s.batchEditApi.GetCellValue(lastposition, "visibleCol");
    Gwidth = s.batchEditApi.GetCellValue(lastposition, "width");
    var z = { Position: Gposition, Width: Gwidth, NPame: GName, GVisible: Gvisible };
    $.post("/Setting/TempUpdate", z, "json")
}

function TreelistUpdate()
{
    TreeList.UpdateEdit();
}

function TreelistClose() {
    TreeList.CancelEdit();

}

function CheckChange(index) {
    var sernum = $('#tbSerN tr:nth-child(' + index + ')').find('td:nth-child(3)').text();
    var sercheck = $('#tbSerN tr:nth-child(' + index + ')').find('td:nth-child(4)').find('input#Kzebu').is(':checked');
    var ser;
    if (sercheck) ser = "X"; else ser = "";
    var z = { SerNumber: sernum, check: ser }
    $.post("/Home/ChangeCHeckSerNumber", z, "json")

}

var selectedIDs;
var currentSearchText = "";
function OnBeginCallbackTL(s, e) {
    //Pass all selected keys to GridView callback action
    e.customArgs["selectedIDs"] = selectedIDs;
    e.customArgs["SearchText"] = currentSearchText;
}
function OnSelectionChangedTL(s, e) {
    s.GetSelectedNodeValues("ID", GetSelectedFieldValuesCallback);
}
function GetSelectedFieldValuesCallback(values) {
    //Capture all selected keys
    selectedIDs = values.join(',');
    $("#selectedNodeIDsMainPage").val(selectedIDs);
}

function onSerchButtomClick() {
    currentSearchText = SerchText1.GetValue();
    TreeList.PerformCallback({ isNewSearch: true });
}

