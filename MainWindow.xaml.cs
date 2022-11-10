using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kooste
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///    
    public record MuistiinPano(string asia, string aihe, string kohdepv);
    public partial class MainWindow : Window
    {
        private static List<MuistiinPano> muistilista = new List<MuistiinPano>();

        const int tammi = 31;
        const int helmi = 59;
        const int maalis = 90;
        const int huhti = 120;
        const int touko = 151;
        const int kesa = 181;
        const int heina = 212;
        const int elo = 243;
        const int syys = 273;
        const int loka = 304;
        const int marras = 334;
        const int joulu = 365;

        public List<TextBlock> viikonpeet = new List<TextBlock>();
        public List<TextBlock> viikonkoot = new List<TextBlock>();
        DateTime eka = new DateTime(2022, 1, 3);
        DateTime kohde = DateTime.Today;
        
        int viikko = 1;
        int alkupee;
        int alkukuu;
        public MainWindow()
        {        
            InitializeComponent();
            alkupee = eka.Day;
            alkukuu = eka.Month;
            viikonlistaus();
            Aloitus();
            int laskuri = 0;
            while (kohde.DayOfYear > 7*viikko)
            {                
                laskuri++;
                if (laskuri % 7 == 0)
                {
                    viikko++;
                }
            }         
            viikkoEteneminen(viikko);
            
            viikko_otsikko.Text ="viikko " + viikko;
        }

        private void viikonlistaus()
        {
            viikonpeet.Add(pNumeroMa);
            viikonpeet.Add(pNumeroTi);
            viikonpeet.Add(pNumeroKe);
            viikonpeet.Add(pNumeroTo);
            viikonpeet.Add(pNumeroPe);
            viikonpeet.Add(pNumeroLa);
            viikonpeet.Add(pNumeroSu);
            viikonkoot.Add(muistiinpano_tietoMa);
            viikonkoot.Add(muistiinpano_tietoTi);
            viikonkoot.Add(muistiinpano_tietoKe);
            viikonkoot.Add(muistiinpano_tietoTo);
            viikonkoot.Add(muistiinpano_tietoPe);
            viikonkoot.Add(muistiinpano_tietoLa);
            viikonkoot.Add(muistiinpano_tietoSu);
        }

        private void viikkoEteneminen(int kerta)
        {
            viikko_otsikko.Text = "viikko " + viikko;
            int temp;
            for (int i = 0; i < viikonpeet.Count; i++)
            {
                temp = 3 + 7 * (kerta - 1) + i;
                switch (temp)
                {
                    case var _ when temp < tammi+1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu, (3 + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < helmi+1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu+1, (3 - tammi + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < maalis+1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 2, (3 - helmi + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < huhti + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 3, (3 - maalis + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < touko + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 4, (3 - huhti + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < kesa + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 5, (3 - touko + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < heina + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 6, (3 - kesa + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < elo + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 7, (3 - heina + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < syys + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 8, (3 - elo + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < loka + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 9, (3 - syys + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < marras + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 10, (3 - loka + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                    case var _ when temp < joulu + 1:
                        viikonpeet[i].Text = new DateTime(2022, alkukuu + 11, (3 - marras + (7 * (viikko - 1)) + i)).ToString("dd/M");
                        break;
                }
            }
            ViikonMuistio();
        }

        private void muistiinpanot_Click(object sender, RoutedEventArgs e)
        {
            string kpv = "";
            if (e.OriginalSource.Equals(lukuMa)) kpv = pNumeroMa.Text;
            if (e.OriginalSource.Equals(lukuTi)) kpv = pNumeroTi.Text;
            if (e.OriginalSource.Equals(lukuKe)) kpv = pNumeroKe.Text;
            if (e.OriginalSource.Equals(lukuTo)) kpv = pNumeroTo.Text;
            if (e.OriginalSource.Equals(lukuPe)) kpv = pNumeroPe.Text;
            if (e.OriginalSource.Equals(lukuLa)) kpv = pNumeroLa.Text;
            if (e.OriginalSource.Equals(LukuSu)) kpv = pNumeroSu.Text;
            List<MuistiinPano> temp = new List<MuistiinPano>();
            foreach (var item in muistilista)
            {
                if (item.kohdepv == kpv)
                {
                    temp.Add(item);
                }
            }
            if (temp.Count > 0)
            {
                lukuWindow ikkuna = new lukuWindow();
                foreach (var item in temp)
                {
                    ikkuna.teksti.Text += item.kohdepv + " " + item.aihe + " " + item.asia + "\n";
                }
                ikkuna.Show();
            }
            else
            {
                MessageBox.Show("tälle päivälle ei ole muistiinpanoja");
            }
        }

        private void uusi_Click(object sender, RoutedEventArgs e)
        {
            string kpv = "";
            string aiheTemp = "";
            UusimpWindow ikkuna = new UusimpWindow();
            if (e.OriginalSource.Equals(nappiMa)) kpv = pNumeroMa.Text;
            if (e.OriginalSource.Equals(nappiTi)) kpv = pNumeroTi.Text;
            if (e.OriginalSource.Equals(nappiKe)) kpv = pNumeroKe.Text;
            if (e.OriginalSource.Equals(nappiTo)) kpv = pNumeroTo.Text;
            if (e.OriginalSource.Equals(nappiPe)) kpv = pNumeroPe.Text;
            if (e.OriginalSource.Equals(nappiLa)) kpv = pNumeroLa.Text;
            if (e.OriginalSource.Equals(nappiSu)) kpv = pNumeroSu.Text;
            //MessageBox.Show(kirjaus.kohdepv);
            if ((bool)ikkuna.ShowDialog())
            {
                switch (ikkuna.AiheValikko.SelectedIndex)
                {
                    case 0:
                        aiheTemp = "Työ";
                        break;
                    case 1:
                        aiheTemp = "Opiskelu";
                        break;
                    case 2:
                        aiheTemp = "Liikunta";
                        break;
                    case 3:
                        aiheTemp = "Muu";
                        break;
                }                
                muistilista.Add(new MuistiinPano(ikkuna.teksti.Text, aiheTemp, kpv));                
                File.WriteAllText("Tieto.json", JsonSerializer.Serialize(muistilista));
            }
            ViikonMuistio();
        }

        private void ViikonMuistio()
        {
            int num = 0;
            int Tnum = 0;
            int Onum = 0;
            int Lnum = 0;
            int Mnum = 0;

            foreach (var item in viikonkoot)
            {
                item.Text = "ei muistiinpanoja";
            }            
            foreach (var item in muistilista)
            {
                int index = 0;
                foreach (var item2 in viikonpeet)
                {
                    
                    if (item.kohdepv == item2.Text)
                    {
                        if (item.kohdepv == item2.Text) viikonkoot[index].Text = "Tälle päivälle on muistiinpanoja";

                        num++;
                        switch (item.aihe)
                        {
                            case "Työ":
                                Tnum++;
                                break;
                            case "Opiskelu":
                                Onum++;
                                break;
                            case "Liikunta":
                                Lnum++;
                                break;
                            case "Muu":
                                Mnum++;
                                break;
                            default:
                                break;
                        }
                    }
                    index++;
                }
            }
            viikkoAiheet.Text = "Viikon Aiheista "+ Tnum + " koskee työtä, " + Onum + " opiskelua, "+ Lnum+" Liikuntaa ja "+ Mnum + " muita aiheita";
            viikkoLM.Text = "Tällä viikolla on " +num+ " muistiinpanoa";
        }

        private void edellinen_Click(object sender, RoutedEventArgs e)
        {
            if (viikko > 1)
            {
                viikko--;
                viikkoEteneminen(viikko);
            }
        }

        private void seuraava_Click(object sender, RoutedEventArgs e)
        {
            if (viikko < 52)
            {
                viikko++;
                viikkoEteneminen(viikko);
            }
        }
        private void Aloitus()
        {
            if (File.Exists("Tieto.json"))
            {
                muistilista = JsonSerializer.Deserialize<List<MuistiinPano>>(File.ReadAllText("Tieto.json"));
            }
        }
    }
}
