using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEO
{
    public partial class TEO : Form
    {
        int itog_dayManager, itog_dayProgrammer;
        double Wd; //= 0.4; //доп. зп
        double Wc; //= 0.302; // ПФ + ФСС + ФФОМС + Страх.взносы
        double Wh; //= 0.6; //накладные расходы  
        double Cm; //затраты на материалы
        double Mv; //затраты на машинное время
        double Zp; //основная зп
        double tm; //= 460; //машинное время компьютера
        double Sm; //= 20; //стоимость 1 часа машинного времени
        double Km; //= 1; //коэффициент мультипрограммности

        int Uk; //частота (периодичность) решения к-й задачи (Uк =247)
        int H; //норматив среднесуточной загрузки, час./день   = 8
        double tx; //трудоемкость однократной обработки информации (tкj = 6);

        public TEO()
        {
            InitializeComponent();
        }

        private void TEO_Load(object sender, EventArgs e)
        {
            #region Оценка конкурентоспособности проекта в сравнении с аналогом

            dataGridViewKTC.Rows.Add(8);
            dataGridViewKTC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewKTC.Rows[0].Cells[0].Value = "Удобство работы (пользовательский интерфейс)";
            dataGridViewKTC.Rows[1].Cells[0].Value = "Новизна (соответствие современным требованиям)";
            dataGridViewKTC.Rows[2].Cells[0].Value = "Соответствие профилю деятельности заказчика";
            dataGridViewKTC.Rows[3].Cells[0].Value = "Ресурсная эффективность";
            dataGridViewKTC.Rows[4].Cells[0].Value = "Надежность (защита данных)";
            dataGridViewKTC.Rows[5].Cells[0].Value = "Скорость доступа к данным";
            dataGridViewKTC.Rows[6].Cells[0].Value = "Гибкость настройки";
            dataGridViewKTC.Rows[7].Cells[0].Value = "Обучаемость персонала";
            dataGridViewKTC.Rows[8].Cells[0].Value = "Соотношение стоимость/возможности";

            #endregion

            #region Планирование комплекса работ по разработке темы и оценка трудоемкости

            string[] row1_1 = new string[] { "Постановка задачи", "Руководитель" };
            string[] row1_2 = new string[] { "", "Программист" };
            string[] row1_3 = new string[] { "Сбор исходных данных", "Руководитель" };
            string[] row1_4 = new string[] { "", "Программист" };
            string[] row1_5 = new string[] { "Анализ существующих методов решения задачи и программных средств", "Руководитель" };
            string[] row1_6 = new string[] { "", "Программист" };
            string[] row1_7 = new string[] { "Обоснование принципиальной необходимости разработки", "Руководитель" };
            string[] row1_8 = new string[] { "", "Программист" };
            string[] row1_9 = new string[] { "Определение и анализ требований к программе", "Руководитель" };
            string[] row1_10 = new string[] { "", "Программист" };
            string[] row1_11 = new string[] { "Определение структуры входных и выходных данных", "Руководитель" };
            string[] row1_12 = new string[] { "", "Программист" };
            string[] row1_13 = new string[] { "Выбор технических средств и программных средств реализации", "Руководитель" };
            string[] row1_14 = new string[] { "", "Программист" };
            string[] row1_15 = new string[] { "Согласование и утверждение технического задания", "Руководитель" };
            string[] row1_16 = new string[] { "", "Программист" };

            string[] row2_1 = new string[] { "Проектирование программной архитектуры", "Руководитель" };
            string[] row2_2 = new string[] { "", "Программист" };
            string[] row2_3 = new string[] { "Техническое проектирование компонентов программы", "Руководитель" };
            string[] row2_4 = new string[] { "", "Программист" };

            string[] row3_1 = new string[] { "Программирование модулей в выбранной среде программирования", "Руководитель" };
            string[] row3_2 = new string[] { "", "Программист" };
            string[] row3_3 = new string[] { "Тестирование программных модулей", "Руководитель" };
            string[] row3_4 = new string[] { "", "Программист" };
            string[] row3_5 = new string[] { "Сборка и испытание программы", "Руководитель" };
            string[] row3_6 = new string[] { "", "Программист" };
            string[] row3_7 = new string[] { "Анализ результатов испытаний", "Руководитель" };
            string[] row3_8 = new string[] { "", "Программист" };

            string[] row4_1 = new string[] { "Проведение расчетов показателей безопасности жизнедеятельности", "Руководитель" };
            string[] row4_2 = new string[] { "", "Программист" };
            string[] row4_3 = new string[] { "Проведение экономических расчетов", "Руководитель" };
            string[] row4_4 = new string[] { "", "Программист" };
            string[] row4_5 = new string[] { "Оформление пояснительной записки", "Руководитель" };
            string[] row4_6 = new string[] { "", "Программист" };

            object[] rows = new object[]
            {
                row1_1, row1_2, row1_3, row1_4, row1_5, row1_6, row1_7, row1_8, row1_9, row1_10, row1_11, row1_12, row1_13, row1_14, row1_15, row1_16,
                row2_1, row2_2, row2_3, row2_4,
                row3_1, row3_2, row3_3, row3_4, row3_5, row3_6, row3_7, row3_8,
                row4_1, row4_2, row4_3, row4_4, row4_5, row4_6
            };

            dataGridViewPlan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (string[] rowArray in rows)
            {
                dataGridViewPlan.Rows.Add(rowArray);
            }

            #endregion

            #region Расчет затрат на разработку проекта

            dataGridViewSalary.Rows.Add(2);
            dataGridViewSalary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSalary.Rows[0].Cells[0].Value = "Руководитель";
            dataGridViewSalary.Rows[1].Cells[0].Value = "Программист";

            dataGridViewMaterial.Rows.Add(4);
            dataGridViewMaterial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewMaterial.Rows[0].Cells[0].Value = "Тетрадь общая";
            dataGridViewMaterial.Rows[1].Cells[0].Value = "Компакт-диск CD-RW";
            dataGridViewMaterial.Rows[2].Cells[0].Value = "Тонер для лазерного принтера";
            dataGridViewMaterial.Rows[3].Cells[0].Value = "Бумага офисная";

            dataGridViewMaterial.Rows[0].Cells[1].Value = "шт.";
            dataGridViewMaterial.Rows[1].Cells[1].Value = "шт.";
            dataGridViewMaterial.Rows[2].Cells[1].Value = "шт.";
            dataGridViewMaterial.Rows[3].Cells[1].Value = "пачка";

            dataGridViewArticle.Rows.Add(6);
            dataGridViewArticle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewArticle.Rows[0].Cells[0].Value = "Основная заработная плата";
            dataGridViewArticle.Rows[1].Cells[0].Value = "Дополнительная зарплата";
            dataGridViewArticle.Rows[2].Cells[0].Value = "Отчисления на социальные нужды";
            dataGridViewArticle.Rows[3].Cells[0].Value = "Затраты на материалы ";
            dataGridViewArticle.Rows[4].Cells[0].Value = "Затраты на машинное время";
            dataGridViewArticle.Rows[5].Cells[0].Value = "Накладные расходы организации";

            dataGridViewOborudovanie.Rows.Add(1);
            dataGridViewOborudovanie.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewOborudovanie.Rows[0].Cells[0].Value = "Компьютер";

            dataGridViewAnalog.Rows.Add(4);
            dataGridViewAnalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAnalog.Rows[0].Cells[0].Value = "Затраты на приобретение программного продукта";
            dataGridViewAnalog.Rows[1].Cells[0].Value = "Затраты по оплате услуг на установку и сопровождение продукта";
            dataGridViewAnalog.Rows[2].Cells[0].Value = "Затраты на основное и вспомогательное оборудование";
            dataGridViewAnalog.Rows[3].Cells[0].Value = "Затраты на подготовку пользователя";

            #endregion

            #region Расчет эксплуатационных затрат

            dataGridViewZpProject.Rows.Add(2);
            dataGridViewZpProject.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewZpProject.Rows[0].Cells[0].Value = "Сотрудник отдела МТС";
            dataGridViewZpProject.Rows[1].Cells[0].Value = "Программист";

            dataGridViewZpAnalog.Rows.Add(2);
            dataGridViewZpAnalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewZpAnalog.Rows[0].Cells[0].Value = "Сотрудник отдела МТС";
            dataGridViewZpAnalog.Rows[1].Cells[0].Value = "Программист";

            /*dataGridViewOborud.Rows.Add(1);
            dataGridViewOborud.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewOborud.Rows[0].Cells[0].Value = "Компьютер";*/

            dataGridViewItog.Rows.Add(7);
            dataGridViewItog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авто высота строк
            dataGridViewItog.Rows[0].Cells[0].Value = "Основная и дополнительная зарплата с отчислениями во внебюджетные фонды";
            dataGridViewItog.Rows[1].Cells[0].Value = "Амортизационные отчисления";
            dataGridViewItog.Rows[2].Cells[0].Value = "Затраты на электроэнергию";
            dataGridViewItog.Rows[3].Cells[0].Value = "Затраты на текущий ремонт";
            dataGridViewItog.Rows[4].Cells[0].Value = "Затраты на материалы";
            dataGridViewItog.Rows[5].Cells[0].Value = "Накладные расходы";
            dataGridViewItog.Rows[6].Cells[0].Value = "Итого";

            #endregion

            #region Расчет показателей экономической эффективности

            dataGridViewEconomEffect.Rows.Add(4);
            dataGridViewEconomEffect.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авто высота строк
            dataGridViewEconomEffect.Rows[0].Cells[0].Value = "Себестоимость (текущие эксплуатационные затраты), руб.";
            dataGridViewEconomEffect.Rows[1].Cells[0].Value = "Суммарные затраты, связанные с внедрением проекта, руб.";
            dataGridViewEconomEffect.Rows[2].Cells[0].Value = "Приведенные затраты на единицу работ, руб.";
            dataGridViewEconomEffect.Rows[3].Cells[0].Value = "Экономический эффект от использования разрабатываемой системы, руб.";

            dataGridViewEconomResults.Rows.Add(5);
            dataGridViewEconomResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авто высота строк
            dataGridViewEconomResults.Rows[0].Cells[0].Value = "Затраты на разработку и внедрение проекта, руб.";
            dataGridViewEconomResults.Rows[1].Cells[0].Value = "Общие эксплуатационные затраты, руб.";
            dataGridViewEconomResults.Rows[2].Cells[0].Value = "Экономический эффект, руб.";
            dataGridViewEconomResults.Rows[3].Cells[0].Value = "Коэффициент экономической эффективности";
            dataGridViewEconomResults.Rows[4].Cells[0].Value = "Срок окупаемости, лет";

            #endregion
        }

        #region Оценка конкурентоспособности проекта в сравнении с аналогом

        private void buttonCalculateKTC_Click(object sender, EventArgs e)
        {
            double J_project = 0;
            double J_analog = 0;
            double Ak_itog = 0;
            double check_Bj = 0;

            foreach (DataGridViewRow row in dataGridViewKTC.Rows)
            {
                double value_BX_project, value_BX_analog, value_Bj;
                double.TryParse((row.Cells[3].Value ?? "0").ToString().Replace(".", ","), out value_BX_project);
                double.TryParse((row.Cells[5].Value ?? "0").ToString().Replace(".", ","), out value_BX_analog);
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out value_Bj);
                J_project += value_BX_project;
                J_analog += value_BX_analog;
                check_Bj += value_Bj;
            }

            if (check_Bj != 1)
            { MessageBox.Show("Коэффициент весомости не равен 1", "Ошибка"); }
            else
            {
                j_project_result.Text = J_project.ToString();
                j_analog_result.Text = J_analog.ToString();
                Ak_itog = Math.Round(J_project / J_analog,2);
                Ak_result.Text = Ak_itog.ToString();
                if (Ak_itog >= 1)
                {
                    itog_KTC.Text = "Разработка проекта с технической точки зрения оправдана";
                    itog_KTC.ForeColor = Color.LightGreen;
                }
                else
                {
                    itog_KTC.Text = "Разработка проекта с технической точки зрения НЕ оправдана";
                    itog_KTC.ForeColor = Color.LightCoral;
                }
            }
        }

        private void dataGridViewKTC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewKTC.Rows)
            {
                double value_Bj, value_X_project, value_X_analog;
                double.TryParse((row.Cells[2].Value ?? "0").ToString().Replace(".", ","), out value_X_project);
                double.TryParse((row.Cells[4].Value ?? "0").ToString().Replace(".", ","), out value_X_analog);
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out value_Bj);
                row.Cells[3].Value = value_Bj * value_X_project;
                row.Cells[5].Value = value_Bj * value_X_analog;
            }
        }

        private void dataGridViewKTC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewKTC.Rows[dataGridViewKTC.CurrentRow.Index].Cells[2].IsInEditMode ||
                dataGridViewKTC.Rows[dataGridViewKTC.CurrentRow.Index].Cells[4].IsInEditMode)
            {
                if ((e.KeyChar <= 48 || e.KeyChar >= 54) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; } //Ввод от 1 до 5
            }

            if (dataGridViewKTC.Rows[dataGridViewKTC.CurrentRow.Index].Cells[1].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',')) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; } //Ввод цифр и запятой
            }
        }

        #endregion

        #region Планирование комплекса работ по разработке темы и оценка трудоемкости

        private void buttonCalculatePlan_Click(object sender, EventArgs e)
        {

            DateTime date = new DateTime();
            DateTime dateProgrammer, dateManeger;

            bool check = false;
            for (int i = 0; i < dataGridViewPlan.RowCount; i++)
            {
                if (dataGridViewPlan.Rows[i].Cells[2].Value == null)
                {
                    check = false;
                    MessageBox.Show("Внесите кол-во дней");
                    break;
                }
                else { check = true; };
            }

            if (check == true)
            {
                dataGridViewPlan.Rows[0].Cells[3].Value = dateTimePicker1.Value.ToString("dd.MM.yyyy"); //Заносим дату пользователя в начало
                dataGridViewPlan.Rows[1].Cells[3].Value = dataGridViewPlan.Rows[0].Cells[3].Value;

                date = Convert.ToDateTime(dataGridViewPlan.Rows[0].Cells[3].Value);
                date = date.AddDays(Convert.ToInt32(dataGridViewPlan.Rows[0].Cells[2].Value) - 1); //Прибавляем дни
                dataGridViewPlan.Rows[0].Cells[4].Value = date.ToShortDateString(); //Заносим дату в конец

                date = Convert.ToDateTime(dataGridViewPlan.Rows[1].Cells[3].Value);
                date = date.AddDays(Convert.ToInt32(dataGridViewPlan.Rows[1].Cells[2].Value) - 1);
                dataGridViewPlan.Rows[1].Cells[4].Value = date.ToShortDateString();


                for (int i = 2; i < dataGridViewPlan.RowCount; i = i + 2)
                {
                    dateManeger = Convert.ToDateTime(dataGridViewPlan.Rows[i - 2].Cells[4].Value);
                    dateProgrammer = Convert.ToDateTime(dataGridViewPlan.Rows[i - 1].Cells[4].Value);
                    if (dateProgrammer > dateManeger)
                        date = Convert.ToDateTime(dataGridViewPlan.Rows[i - 1].Cells[4].Value); //Предыдущая дата                       
                    else date = Convert.ToDateTime(dataGridViewPlan.Rows[i - 2].Cells[4].Value);

                    date = date.AddDays(1); //Прибавляем день с новой работы
                    dataGridViewPlan.Rows[i].Cells[3].Value = date.ToShortDateString();
                    date = date.AddDays(Convert.ToInt32(dataGridViewPlan.Rows[i].Cells[2].Value) - 1);
                    dataGridViewPlan.Rows[i].Cells[4].Value = date.ToShortDateString();

                    dataGridViewPlan.Rows[i + 1].Cells[3].Value = dataGridViewPlan.Rows[i].Cells[3].Value;

                    date = Convert.ToDateTime(dataGridViewPlan.Rows[i + 1].Cells[3].Value);
                    date = date.AddDays(Convert.ToInt32(dataGridViewPlan.Rows[i + 1].Cells[2].Value) - 1);
                    dataGridViewPlan.Rows[i + 1].Cells[4].Value = date.ToShortDateString();
                }
            }

            //Суммирование дней
            int dayManager = 0;
            int dayProgrammer = 0;
            for (int i = 0; i < dataGridViewPlan.RowCount; i = i + 2)
            {
                dayManager += Convert.ToInt32(dataGridViewPlan.Rows[i].Cells[2].Value);
                dayProgrammer += Convert.ToInt32(dataGridViewPlan.Rows[i + 1].Cells[2].Value);
            }
            itog_days_manager.Text = dayManager.ToString();
            itog_days_programmer.Text = dayProgrammer.ToString();
            itog_dayManager = dayManager;
            itog_dayProgrammer = dayProgrammer;
        }

        private void dataGridViewPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb11 = (TextBox)e.Control;
            tb11.KeyPress += new KeyPressEventHandler(tb11_KeyPress);
        }
        void tb11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewPlan.Rows[dataGridViewPlan.CurrentRow.Index].Cells[2].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        #endregion

        #region Расчет затрат на разработку проекта

        private void buttonCalculateDev_Click(object sender, EventArgs e)
        {
            double dayMonth = 0;
            if (tb_DayMonth.Text != "")
                dayMonth = double.Parse(tb_DayMonth.Text);
            else MessageBox.Show("Введите кол-во рабочих дней в месяц");

            double salary, avg_salary;
            int itog_days;
            foreach (DataGridViewRow row in dataGridViewSalary.Rows)
            {
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out salary);

                avg_salary = Math.Round(salary / dayMonth, 2);
                row.Cells[2].Value = avg_salary; //Средняя дневная ставка 

                dataGridViewSalary.Rows[0].Cells[3].Value = itog_dayManager;
                dataGridViewSalary.Rows[1].Cells[3].Value = itog_dayProgrammer;

                itog_days = Convert.ToInt32(row.Cells[3].Value);
                row.Cells[4].Value = avg_salary * itog_days;

                //Суммирование
                double all_salary= 0;
                for (int i = 0; i < dataGridViewSalary.RowCount; i++)
                {
                    all_salary += Convert.ToDouble(dataGridViewSalary.Rows[i].Cells[4].Value);
                }
                itog_ozp.Text = all_salary.ToString();
                Zp = all_salary;
            }

            double all_sum = 0;
            for (int i = 0; i < dataGridViewMaterial.RowCount; i++)
            {
                all_sum += Convert.ToDouble(dataGridViewMaterial.Rows[i].Cells[4].Value);
            }
            itog_sum_material.Text = all_sum.ToString();
            Cm = all_sum;

            if (tb_naclad.Text != "")
                Wh = double.Parse(tb_naclad.Text);
            if ((tb_pf.Text != "") || (tb_fcc.Text != "") || (tb_ffomc.Text != "") || (tb_ctrax.Text != ""))
                Wc = double.Parse(tb_pf.Text) + double.Parse(tb_fcc.Text) + double.Parse(tb_ffomc.Text) + double.Parse(tb_ctrax.Text);
            if ((tb_ko.Text != "") || (tb_kr.Text != ""))
                Wd = double.Parse(tb_ko.Text) + double.Parse(tb_kr.Text);

            if (tb_tmv.Text != "")
                tm = Convert.ToInt32(tb_tmv.Text);
            if (tb_cost1h.Text != "")
                Sm = double.Parse(tb_cost1h.Text);
            if (tb_kmulti.Text != "")
                Km = double.Parse(tb_kmulti.Text);
            Mv = tm * Sm * Km;

            double Kp, Kr;

            Kp = Math.Round(Zp * ((1 + Wd) * (1 + Wc) + Wh) + Mv + Cm, 2);
            tb_Kp.Text = Kp.ToString();

            double all_sum_oborud = 0;

            if (tb_Uk.Text != "")
                Uk = Convert.ToInt32(tb_Uk.Text);

            if (tb_H.Text != "")
                H = Convert.ToInt32(tb_H.Text); 

            if (tb_tx.Text != "")
                tx = double.Parse(tb_tx.Text);

            foreach (DataGridViewRow row in dataGridViewOborudovanie.Rows) //Сумма оборудования
            {
                all_sum_oborud += Convert.ToDouble(row.Cells[3].Value);
            }
            itog_sum_oborud.Text = all_sum_oborud.ToString();

            Kr = Math.Round(all_sum_oborud * tx * Uk / (Uk * H), 2);
            tb_Kr2.Text = Kr.ToString();
          
            tb_Kitog.Text = Math.Round(Kr + Kp, 2).ToString();

            dataGridViewArticle.Rows[0].Cells[1].Value = Math.Round(Zp, 2); //ОЗП
            dataGridViewArticle.Rows[1].Cells[1].Value = Math.Round(Zp * Wd, 2); //Дополнительная зарплата
            dataGridViewArticle.Rows[2].Cells[1].Value = Math.Round((Zp + (Zp * Wd)) * Wc, 2);// Отчисления на социальные нужды 
            dataGridViewArticle.Rows[3].Cells[1].Value = Math.Round(Cm, 2); //Затраты на материалы 
            dataGridViewArticle.Rows[4].Cells[1].Value = Math.Round(tm * Sm, 2); //Затраты на машинное время
            dataGridViewArticle.Rows[5].Cells[1].Value = Math.Round(Zp * Wh, 2); //Накладные расходы организации 

            double sum_article_itog = 0;
            for (int i = 0; i < dataGridViewArticle.RowCount; i++)
            {
                sum_article_itog += Convert.ToDouble(dataGridViewArticle.Rows[i].Cells[1].Value);
            }
            itog_sum_develop.Text = sum_article_itog.ToString();

            double sum_zatrat_itog = 0;
            foreach (DataGridViewRow row in dataGridViewAnalog.Rows)
            {
                sum_zatrat_itog += Convert.ToDouble(row.Cells[1].Value);
            }
            itog_sum_analog.Text = sum_zatrat_itog.ToString();
        }

        private void dataGridViewSalary_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewSalary_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb1 = (TextBox)e.Control;
            tb1.KeyPress += new KeyPressEventHandler(tb1_KeyPress);
        }
        void tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewSalary.Rows[dataGridViewSalary.CurrentRow.Index].Cells[1].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',')) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        private void dataGridViewMaterial_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double incom1, incom2;
            foreach (DataGridViewRow row in dataGridViewMaterial.Rows)
            {
                incom1 = Convert.ToDouble(row.Cells[2].Value);
                double.TryParse((row.Cells[3].Value ?? "0").ToString().Replace(".", ","), out incom2);
                row.Cells[4].Value = incom1 * incom2;
            }
        }
        private void dataGridViewMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb2 = (TextBox)e.Control;
            tb2.KeyPress += new KeyPressEventHandler(tb2_KeyPress);
        }
        void tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[3].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',') && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
            if (dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[2].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        private void dataGridViewOborudovanie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double incom1, incom2;
            foreach (DataGridViewRow row in dataGridViewOborudovanie.Rows)
            {
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out incom1);
                incom2 = Convert.ToDouble(row.Cells[2].Value);
                row.Cells[3].Value = incom1 * incom2;
            }
        }
        private void dataGridViewOborudovanie_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb3 = (TextBox)e.Control;
            tb3.KeyPress += new KeyPressEventHandler(tb3_KeyPress);
        }
        void tb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewOborudovanie.Rows[dataGridViewOborudovanie.CurrentRow.Index].Cells[1].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',') && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
            if (dataGridViewOborudovanie.Rows[dataGridViewOborudovanie.CurrentRow.Index].Cells[2].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        #endregion

        #region Расчет эксплуатационных затрат

        private void buttonCalculateZatrat_Click(object sender, EventArgs e)
        {
            double dayMonth1 = 0;
            if (tb_DayMonth2.Text != "")
                dayMonth1 = double.Parse(tb_DayMonth2.Text);
            else MessageBox.Show("Введите кол-во рабочих дней в месяц");

            /*if (tb_naclad.Text != "")
                Wh = double.Parse(tb_naclad.Text);*/
            if ((tb_pf2.Text != "") || (tb_fcc2.Text != "") || (tb_ffomc2.Text != "") || (tb_ctrax2.Text != ""))
                Wc = double.Parse(tb_pf2.Text) + double.Parse(tb_fcc2.Text) + double.Parse(tb_ffomc2.Text) + double.Parse(tb_ctrax2.Text);
            if ((tb_ko1.Text != "") || (tb_kr1.Text != ""))
                Wd = double.Parse(tb_ko1.Text) + double.Parse(tb_kr1.Text);

            double salary2, salary1, avg_salary2, avg_salary1, zp_project, zp_analog;
            int itog_days2, itog_days1;
            foreach (DataGridViewRow row in dataGridViewZpProject.Rows)
            {
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out salary2);

                avg_salary2 = Math.Round(salary2 / dayMonth1, 2);
                row.Cells[2].Value = avg_salary2; //Средняя дневная ставка 

                itog_days2 = Convert.ToInt32(row.Cells[3].Value);
                row.Cells[4].Value = avg_salary2 * itog_days2 * (1 + Wd) * (1 + Wc);

                //Суммирование
                double all_salary2 = 0;
                for (int i = 0; i < dataGridViewZpProject.RowCount; i++)
                {
                    all_salary2 += Convert.ToDouble(dataGridViewZpProject.Rows[i].Cells[4].Value);
                }
                zp_project = Math.Round(all_salary2, 2);
                itog_zpProject.Text = zp_project.ToString();
            }

            foreach (DataGridViewRow row in dataGridViewZpAnalog.Rows)
            {
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out salary1);

                avg_salary1 = Math.Round(salary1 / dayMonth1, 2);
                row.Cells[2].Value = avg_salary1; //Средняя дневная ставка 

                itog_days1 = Convert.ToInt32(row.Cells[3].Value);
                row.Cells[4].Value = avg_salary1 * itog_days1 * (1 + Wd) * (1 + Wc);

                //Суммирование
                double all_salary1 = 0;
                for (int i = 0; i < dataGridViewZpAnalog.RowCount; i++)
                {
                    all_salary1 += Convert.ToDouble(dataGridViewZpAnalog.Rows[i].Cells[4].Value);
                }
                zp_analog = Math.Round(all_salary1, 2);
                itog_zpAnalog.Text = zp_analog.ToString();
            }


            int D = 0, H = 0;
            if (tb_DayMonth2.Text != "")
                D = Convert.ToInt32(tb_d2.Text); //Кол дней
            if (tb_h2.Text != "")
                H = Convert.ToInt32(tb_h2.Text); //Час/день

            int F = H * D; //эффективный фонд времени работы оборудования в год, час            
            double t_project = 0; // время работы j - гo вида оборудования, час (для проекта)
            double t_analog = 0; // время работы j - гo вида оборудования, час (для аналога)
            double sum1 = 0, sum2 = 0; //Основная и дополнительная зарплата с отчислениями во внебюджетные фонды
            double sum_ob = 0; // Сумма (стоимость оборудования * шт)
            double sum_a1, sum_a2; //Сумма амортизационных отчислений

            double g = 0;//количество единиц оборудования j-гo вида.
            foreach (DataGridViewRow row in dataGridViewOborudovanie.Rows)
            { g += Convert.ToDouble(row.Cells[1].Value); }


            double aj = 0; //норма годовых амортизационных отчислений для j-гo вида оборудования
            if (tb_a2.Text != "")
                aj = double.Parse(tb_a2.Text);

            foreach (DataGridViewRow row in dataGridViewZpProject.Rows)
            {
                sum1 += Convert.ToDouble(row.Cells[4].Value);
                t_project += Convert.ToDouble(row.Cells[3].Value);
            }

            foreach (DataGridViewRow row in dataGridViewZpAnalog.Rows)
            {
                sum2 += Convert.ToDouble(row.Cells[4].Value);
                t_analog += Convert.ToDouble(row.Cells[3].Value);
            }

            t_project = t_project * H; //Время работы оборудования
            t_analog = t_analog * H;

            foreach (DataGridViewRow row in dataGridViewOborudovanie.Rows)// Сумма (стоимость оборудования * шт)
            { sum_ob += Convert.ToDouble(row.Cells[3].Value); }

            sum_a1 = Math.Round((sum_ob * aj * g * t_project) / F, 2);
            sum_a2 = Math.Round((sum_ob * aj * g * t_analog) / F, 2);

           
            double Ze1, Ze2; //Затраты на силовую энергию
            double Ni = 0; //установленная мощность j-го вида технических средств, кВт;
            if (tb_n2.Text != "")
                Ni = double.Parse(tb_n2.Text);

            double Te = 0; // тариф на электроэнергию, руб./ кВт ч.            
            if (tb_t2.Text != "")
                Te = double.Parse(tb_t2.Text);

            double gi = 0; //коэффициент использования установленной мощности оборудования;
            if (tb_g2.Text != "")
                gi = double.Parse(tb_g2.Text);

            Ze1 = Math.Round(Ni * gi * t_project * Te, 2);
            Ze2 = Math.Round(Ni * gi * t_analog * Te, 2);

            
            double Cp = 0; //норматив затрат на ремонт
            if (tb_c_remont.Text != "")
                Cp = double.Parse(tb_c_remont.Text);

            double zr_ob_1, zr_ob_2; //Затраты на текущий ремонт оборудования
            zr_ob_1 = Math.Round((Cp * sum_ob * t_project) / F, 2);
            zr_ob_2 = Math.Round((Cp * sum_ob * t_analog) / F, 2);

            
            double Zm = 0; // Затраты на материалы, потребляемые в течение года          
            if (tb_zatrat_material.Text != "")
                Zm = double.Parse(tb_zatrat_material.Text);
            double ZrM; //Затраты на материалы           
            ZrM = Math.Round(sum_ob * Zm, 2);


            double normat_naclad = 0; //Норматив накладных расходов
            if (tb_naclad2.Text != "")
                normat_naclad = double.Parse(tb_naclad2.Text);
            double Zn1, Zn2; //Накладные расходы           
            Zn1 = Math.Round((sum1 + sum_a1 + Ze1 + ZrM + zr_ob_1) * normat_naclad, 2);
            Zn2 = Math.Round((sum2 + sum_a2 + Ze2 + ZrM + zr_ob_2) * normat_naclad, 2);


            double itog1 = sum1 + sum_a1 + Ze1 + zr_ob_1 + ZrM + Zn1;
            double itog2 = sum2 + sum_a2 + Ze2 + zr_ob_2 + ZrM + Zn2;


            dataGridViewItog.Rows[0].Cells[1].Value = sum1;
            dataGridViewItog.Rows[0].Cells[2].Value = sum2;
            dataGridViewItog.Rows[1].Cells[1].Value = sum_a1;
            dataGridViewItog.Rows[1].Cells[2].Value = sum_a2;
            dataGridViewItog.Rows[2].Cells[1].Value = Ze1;
            dataGridViewItog.Rows[2].Cells[2].Value = Ze2;
            dataGridViewItog.Rows[3].Cells[1].Value = zr_ob_1;
            dataGridViewItog.Rows[3].Cells[2].Value = zr_ob_2;
            dataGridViewItog.Rows[4].Cells[1].Value = ZrM;
            dataGridViewItog.Rows[4].Cells[2].Value = ZrM;
            dataGridViewItog.Rows[5].Cells[1].Value = Zn1;
            dataGridViewItog.Rows[5].Cells[2].Value = Zn2;
            dataGridViewItog.Rows[6].Cells[1].Value = itog1;
            dataGridViewItog.Rows[6].Cells[2].Value = itog2;
        }

        private void dataGridView6_CellValueChanged(object sender, DataGridViewCellEventArgs e) //Табл по заработной плате специалистов (для проекта)
        {
        }

        private void dataGridView6_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb4 = (TextBox)e.Control;
            tb4.KeyPress += new KeyPressEventHandler(tb4_KeyPress);
        }

        void tb4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dataGridViewZpProject.Rows[dataGridViewZpProject.CurrentRow.Index].Cells[1].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',') && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
            if (dataGridViewZpProject.Rows[dataGridViewZpProject.CurrentRow.Index].Cells[3].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        private void dataGridView7_CellValueChanged(object sender, DataGridViewCellEventArgs e)//Табл по заработной плате специалистов (для продукта-аналога)
        {
        }
        private void dataGridView7_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//ОГРАНИЧЕНИЕ 
        {
            TextBox tb5 = (TextBox)e.Control;
            tb5.KeyPress += new KeyPressEventHandler(tb5_KeyPress);
        }
        void tb5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dataGridViewZpAnalog.Rows[dataGridViewZpAnalog.CurrentRow.Index].Cells[1].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',') && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
            if (dataGridViewZpAnalog.Rows[dataGridViewZpAnalog.CurrentRow.Index].Cells[3].IsInEditMode)
            {
                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            }
        }

        #endregion

        #region Расчет показателей экономической эффективности

        private void buttonCalculateEconom_Click(object sender, EventArgs e)
        {
            double Z1, Z2; //приведенные затраты на единицу работ, выполняемых с помощью базового и проектируемого вариантов процесса обработки информации, руб.;
            double En = 0;  //нормативный коэффициент экономической эффективности
            if (tb_en.Text != "")
            { En = double.Parse(tb_en.Text); }
            double Ki1 = 0, Ki2 = 0; //суммарные затраты, связанные с внедрением нового проекта. 
            double Ci1 = 0, Ci2 = 0; //себестоимость (текущие эксплуатационные затраты единицы работ), руб.;

            Ci1 = Convert.ToDouble(dataGridViewItog.Rows[6].Cells[2].Value);
            Ci2 = Convert.ToDouble(dataGridViewItog.Rows[6].Cells[1].Value);

            foreach (DataGridViewRow row in dataGridViewAnalog.Rows)
            {
                double analog;
                double.TryParse((row.Cells[1].Value ?? "0").ToString().Replace(".", ","), out analog);
                Ki1 += analog;
            }
            if (tb_Kitog.Text != "")
            { Ki2 = double.Parse(tb_Kitog.Text); }

            Z1 = Math.Round(Ci1 + En * Ki1, 2);
            Z2 = Math.Round(Ci2 + En * Ki2, 2);

            double E;
            double Ak = 0;
            if (Ak_result.Text != "")
            { Ak = double.Parse(Ak_result.Text); }

            E = Math.Round(Z1 * Ak - Z2, 2);

            dataGridViewEconomEffect.Rows[0].Cells[1].Value = Ci1;
            dataGridViewEconomEffect.Rows[0].Cells[2].Value = Ci2;
            dataGridViewEconomEffect.Rows[1].Cells[1].Value = Ki1;
            dataGridViewEconomEffect.Rows[1].Cells[2].Value = Ki2;
            dataGridViewEconomEffect.Rows[2].Cells[1].Value = Z1;
            dataGridViewEconomEffect.Rows[2].Cells[2].Value = Z2;
            dataGridViewEconomEffect.Rows[3].Cells[1].Value = E;
            dataGridViewEconomEffect.Rows[3].Cells[2].Value = E;

            double Tok = 0;
            Tok = Math.Round(Ki2 / E, 2); //срок окупаемости затрат на разработку
            double Ef = 0;
            Ef = Math.Round(1 / Tok, 2); //фактический коэффициент экономической эффективности разработки

            dataGridViewEconomResults.Rows[0].Cells[1].Value = Ki2;
            dataGridViewEconomResults.Rows[1].Cells[1].Value = Ci2;
            dataGridViewEconomResults.Rows[2].Cells[1].Value = E;
            dataGridViewEconomResults.Rows[3].Cells[1].Value = Ef;
            dataGridViewEconomResults.Rows[4].Cells[1].Value = Tok;

            if (En < Ef)
            {
                itog_EconomResult.Text = "Проект эффективен";
                itog_EconomResult.ForeColor = Color.LightGreen;
            }
            else
            {
                itog_EconomResult.Text = "Проект не эффективен";
                itog_EconomResult.ForeColor = Color.LightCoral;
            }
        }

        #endregion


        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_en.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ko.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_kr.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox113_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ko1.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox115_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_kr1.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_naclad.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_cost1h.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_kmulti.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_pf.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_fcc.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ffomc.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ctrax.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox109_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_pf2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox110_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_fcc2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox111_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ffomc2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox112_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ctrax2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_n2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_g2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_a2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        /*private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && textBox22.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }*/

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_c_remont.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_ko1.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_kr1.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_zatrat_material.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_naclad2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_tx.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_Uk.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox192_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_d2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ',' && tb_t2.Text.IndexOf(",") == -1) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { e.Handled = true; }
        }

        private void GroupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox21_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void tabPagePlan_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tb_Kp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tb_ko_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
