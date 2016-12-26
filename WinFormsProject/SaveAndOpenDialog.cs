

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject
{
    /// <summary>
    /// Класс для созъхранения и открытия рисунков
    /// </summary>
    class SaveAndOpenDialog
    {
        /// <summary>
        /// Сохранение рисунка
        /// </summary>
        /// <param name="bmpToSave">Рисунок</param>
        /// <returns>True, если сохранил</returns>
        public bool saveBMP(Bitmap bmpToSave)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Сохранить картинку как ...";
            saveDialog.OverwritePrompt = true;
            saveDialog.CheckPathExists = true;
            saveDialog.Filter = "Image Files(*.BMP)|*.BMP";
            saveDialog.ShowHelp = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmpToSave.Save(saveDialog.FileName);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Открытие рисунка
        /// </summary>
        /// <returns>Рисунок</returns>
        public Bitmap openBMP()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Выберите картинку";
            openDialog.InitialDirectory = "c:\\";
            openDialog.Filter = "bmp files (*.bmp)|*.bmp";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(openDialog.FileName);
            }
            return null;
        }
    }

    
}
