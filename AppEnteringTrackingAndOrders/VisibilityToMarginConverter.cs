using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace AppEnteringTrackingAndOrders
{
    public class VisibilityToMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double initialOffset = 0; // Начальный отступ (рядом с логином)
            double additionalOffset = 90; // Смещение для каждой видимой границы (можно изменить по необходимости)

            // Подсчитываем количество видимых элементов
            int visibleCount = 0;
            foreach (var value in values)
            {
                if (value is Visibility visibility && visibility == Visibility.Visible)
                {
                    visibleCount++;
                }
            }

            // Если видим хотя бы один элемент, добавляем смещение
            return new Thickness(0, initialOffset + (additionalOffset * visibleCount), 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConditionalMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !(values[0] is Visibility visibilityOne) || !(values[1] is Visibility visibilityTwo))
            {
                return new Thickness(0);
            }
            if (visibilityOne == Visibility.Visible && visibilityTwo == Visibility.Visible)
            {
                // Оба видимы, оставляем на стандартной позиции
                return new Thickness(0, 90, 0, 0);
            }
            else
            {
                // В других случаях - по умолчанию
                return new Thickness(0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
