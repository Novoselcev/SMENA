using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading;

namespace SSZ.Models
{
    public class DefectOZM
    {
       public  Int32 Stufe {get; set;} // – уровень спецификации(вместо Aflst, чтобы ближе к стандарту)
        public Int32 Wegxx { get; set; }// – ИД узла спецификации внутри уровня
        public Int32 Vwegx { get; set; } // – Путь разузлования многоуровневой спецификации.
        public string Posnr { get; set; }// – Номер позиции. Обычно доступен на изменение пользователю, чтобы расположить дефектные компоненты в порядке убывания важности;
        public string Aflst { get; set; }// – Уровень в дереве разузлования.Только просмотр (для удобства пользователя);
        public string Bautl { get; set; }// – номер ОЗМ дефектного компонента.Только просмотр;
        public string BautlTxt { get; set; } // – краткий текст к ОЗМ дефектного компонента.Только просмотр;
        public string Prueflinr {get; set;}// – внешний номер дефектного объекта.Обычно туда пользователь заносит координаты дефектного компонента;
        public string Anzfehler { get; set; } // -- Число обнаруженных дефектов.Вносит пользователь;
        public string Fmgeig { get; set; } // -- Дефектное количество компонента.Вносит пользователь(вероятно пользователю надо показать что-то одно из Anzfehler и Fmgeig);
        public string Fmgein { get; set; }// – Единица измерения дефектного количества компонента.Только просмотр;
        public string FlgMark { get; set; }// – Пометка выбора(типа checkbox). Выставляет пользователь;
        public Int32 ID { get; set; }
        public Int32 ID_parent { get; set; }
    }

   
}