using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public class RussianRadGridLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            // todo add custom formatting localization
            switch (id)
            {
                case RadGridStringId.FilterOperatorBetween:
                    return "между";
                case RadGridStringId.FilterOperatorContains:
                    return "содержит";
                case RadGridStringId.FilterOperatorDoesNotContain:
                    return "не содержит";
                case RadGridStringId.FilterOperatorEndsWith:
                    return "заканчивается на";
                case RadGridStringId.FilterOperatorEqualTo:
                    return "равно";
                case RadGridStringId.FilterOperatorGreaterThan:
                    return "больше";
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo:
                    return "больше или равно";
                case RadGridStringId.FilterOperatorIsEmpty:
                    return "пусто";
                case RadGridStringId.FilterOperatorIsNull:
                    return "без значения";
                case RadGridStringId.FilterOperatorLessThan:
                    return "меньше";
                case RadGridStringId.FilterOperatorLessThanOrEqualTo:
                    return "меньше или равно";
                case RadGridStringId.FilterOperatorNoFilter:
                    return "без фильтра";
                case RadGridStringId.FilterOperatorNotBetween:
                    return "не между";
                case RadGridStringId.FilterOperatorNotEqualTo:
                    return "не равно";
                case RadGridStringId.FilterOperatorNotIsEmpty:
                    return "не пусто";
                case RadGridStringId.FilterOperatorNotIsNull:
                    return "со значением";
                case RadGridStringId.FilterOperatorStartsWith:
                    return "начинается с";
                case RadGridStringId.FilterOperatorIsLike:
                    return "похож";
                case RadGridStringId.FilterOperatorNotIsLike:
                    return "не похож";
                case RadGridStringId.FilterOperatorIsContainedIn:
                    return "содержится в";
                case RadGridStringId.FilterOperatorNotIsContainedIn:
                    return "не содержится в";
                case RadGridStringId.FilterOperatorCustom:
                    return "настраиваемый фильтр";
                case RadGridStringId.FilterFunctionBetween:
                    return "между";
                case RadGridStringId.FilterFunctionContains:
                    return "содержит";
                case RadGridStringId.FilterFunctionDoesNotContain:
                    return "не содержит";
                case RadGridStringId.FilterFunctionEndsWith:
                    return "заканчивается на";
                case RadGridStringId.FilterFunctionEqualTo:
                    return "равно";
                case RadGridStringId.FilterFunctionGreaterThan:
                    return "больше";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo:
                    return "больше или равно";
                case RadGridStringId.FilterFunctionIsEmpty:
                    return "пусто";
                case RadGridStringId.FilterFunctionIsNull:
                    return "без значения";
                case RadGridStringId.FilterFunctionLessThan:
                    return "меньше";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo:
                    return "меньше или равно";
                case RadGridStringId.FilterFunctionNoFilter:
                    return "без фильтра";
                case RadGridStringId.FilterFunctionNotBetween:
                    return "не между";
                case RadGridStringId.FilterFunctionNotEqualTo:
                    return "не равно";
                case RadGridStringId.FilterFunctionNotIsEmpty:
                    return "не пусто";
                case RadGridStringId.FilterFunctionNotIsNull:
                    return "со значением";
                case RadGridStringId.FilterFunctionStartsWith:
                    return "начинается с";
                case RadGridStringId.FilterFunctionCustom:
                    return "настраиваемый фильтр";
                case RadGridStringId.CustomFilterMenuItem:
                    return "Настраиваемый фильтр";
                case RadGridStringId.CustomFilterDialogCaption:
                    return "Настраиваемый фильтр";
                case RadGridStringId.CustomFilterDialogLabel:
                    return "Показать только те строки, значения которых: ";
                case RadGridStringId.CustomFilterDialogRbAnd:
                    return "И";
                case RadGridStringId.CustomFilterDialogRbOr:
                    return "ИЛИ";
                case RadGridStringId.CustomFilterDialogBtnOk:
                    return "ОК";
                case RadGridStringId.CustomFilterDialogBtnCancel:
                    return "Отмена";
                case RadGridStringId.DeleteRowMenuItem:
                    return "Удалить";
                case RadGridStringId.SortAscendingMenuItem:
                    return "Сортировка по возрастанию";
                case RadGridStringId.SortDescendingMenuItem:
                    return "Сортировка по убыванию";
                case RadGridStringId.ClearSortingMenuItem:
                    return "Убрать сортировку";
                case RadGridStringId.ConditionalFormattingMenuItem:
                    return "Условное форматирование";
                case RadGridStringId.GroupByThisColumnMenuItem:
                    return "Группировать по выбранной колонке";
                case RadGridStringId.UngroupThisColumn:
                    return "Отменить группировку по этой колонке";
                case RadGridStringId.ColumnChooserMenuItem:
                    return "Выбрать колонки";
                case RadGridStringId.HideMenuItem:
                    return "Скрыть";
                case RadGridStringId.UnpinMenuItem:
                    return "Открепить";
                case RadGridStringId.PinMenuItem:
                    return "Прикрепить";
                case RadGridStringId.PinAtLeftMenuItem:
                    return "Прикрепить слева";
                case RadGridStringId.PinAtRightMenuItem:
                    return "Прикрепить справа";
                case RadGridStringId.BestFitMenuItem:
                    return "Выровнять";
                case RadGridStringId.PasteMenuItem:
                    return "Вставить";
                case RadGridStringId.EditMenuItem:
                    return "Редактировать";
                case RadGridStringId.CopyMenuItem:
                    return "Копировать";
                case RadGridStringId.ClearValueMenuItem:
                    return "Очистить ячейку";
                case RadGridStringId.AddNewRowString:
                    return "Нажмите здесь, чтобы добавить новую строку";
                case RadGridStringId.ConditionalFormattingCaption:
                    return "Условное форматирование";
                case RadGridStringId.ConditionalFormattingLblColumn:
                    return "Spalte:";
                case RadGridStringId.ConditionalFormattingLblName:
                    return "Имя:";
                case RadGridStringId.ConditionalFormattingLblType:
                    return "Тип:";
                case RadGridStringId.ConditionalFormattingRuleAppliesOn:
                    return "Правило применяется при";
                case RadGridStringId.ConditionalFormattingLblValue1:
                    return "Значение 1:";
                case RadGridStringId.ConditionalFormattingLblValue2:
                    return "Значение 2:";
                case RadGridStringId.ConditionalFormattingGrpConditions:
                    return "Auflagen";
                case RadGridStringId.ConditionalFormattingGrpProperties:
                    return "Eigenschaften";
                case RadGridStringId.ConditionalFormattingChkApplyToRow:
                    return "Применять к строке";
                case RadGridStringId.ConditionalFormattingBtnAdd:
                    return "Добавить";
                case RadGridStringId.ConditionalFormattingBtnRemove:
                    return "Удалить";
                case RadGridStringId.ConditionalFormattingBtnOK:
                    return "OK";
                case RadGridStringId.ConditionalFormattingBtnCancel:
                    return "Отмена";
                case RadGridStringId.ConditionalFormattingBtnApply:
                    return "Применить";
                case RadGridStringId.ColumnChooserFormCaption:
                    return "Выбор колонок";
                case RadGridStringId.ColumnChooserFormMessage:
                    return "Перетяните заголовок колонки\nиз таблица для удаления \nиз текущего вида";
                case RadGridStringId.CustomFilterDialogCheckBoxNot:
                    return "НЕ";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
