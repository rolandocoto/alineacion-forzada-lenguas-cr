using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace correctorTextGrid_01
{



    public partial class corrector : Form
    {
        public corrector()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //txt_TextGridUncorrected.Text = "C:\\Users\\Bender\\Desktop\\uofa\\artículos y congresos\\201602 nlp-crc bribri\\favealign tests\\bribri\\bribri canción isola\\bribri-isola.TextGrid";
            //txt_textGridHandCorrected.Text = "C:\\Users\\Bender\\Desktop\\uofa\\artículos y congresos\\201602 nlp-crc bribri\\favealign tests\\bribri\\bribri canción isola\\bribri-isola-corregAMano.TextGrid";

            //txt_TextGridUncorrected.Text = "C:\\Users\\Bender\\Desktop\\uofa\\artículos y congresos\\201602 nlp-crc bribri\\easyalign tests\\sofía bribri 01\\B03h09m31s06apr2012resultado.TextGrid";
            //txt_textGridHandCorrected.Text = "C:\\Users\\Bender\\Desktop\\uofa\\artículos y congresos\\201602 nlp-crc bribri\\easyalign tests\\sofía bribri 01\\B03h09m31s06apr2012resultado-corregAMano.TextGrid";

            /*txt_TextGridUncorrected.Text = "";
            txt_textGridHandCorrected.Text = "";*/

        }

        private void btn_fileTextGrid_Click(object sender, EventArgs e)
        {

            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK)
            {

                txt_textGrid.Text = openFileTextGrid.FileName;

            }
        }

        private string calculateRMS( interval[] uncorrected, interval[] corrected, string tagType, string tagTypeNum ) {

            string outputLine = "";

            string[] previousPhone = new string[uncorrected.Length];
            string[] followingPhone = new string[uncorrected.Length];
            //string[] previousWord = new string[uncorrected.Length];
            //string[] followingWord = new string[uncorrected.Length];

            double[] diffStartPhonemes = new double[uncorrected.Length];
            double[] rmsDiffStartPhonemes = new double[uncorrected.Length];
            double[] diffEndPhonemes = new double[uncorrected.Length];
            double[] rmsDiffEndPhonemes = new double[uncorrected.Length];

            double tempDiffStart = 0;
            double tempRMSDiffStart = 0;
            double tempDiffEnd = 0;
            double tempRMSDiffEnd = 0;

            double uncorrLen = 0;
            double corrLen = 0;
            double diffLen = 0;
            double RMSdiffLen = 0;

            String textOfTheGrid = "";

            for (int i = 0; i < uncorrected.Length; i++) {

                textOfTheGrid = uncorrected[i].text.Replace("\"", "");
                textOfTheGrid = textOfTheGrid.TrimEnd(' ');
                Console.WriteLine(textOfTheGrid);
                Console.WriteLine(uncorrected[i].text);

                if (textOfTheGrid.Equals("sp") == false && textOfTheGrid.Equals("_") ==false && textOfTheGrid.Equals("") == false) {

                    tempDiffStart = corrected[i].xmin - uncorrected[i].xmin;
                    tempRMSDiffStart = Math.Sqrt(Math.Pow(tempDiffStart, 2));
                    diffStartPhonemes[i] = tempDiffStart;
                    rmsDiffStartPhonemes[i] = tempRMSDiffStart;

                    tempDiffEnd = corrected[i].xmax - uncorrected[i].xmax;
                    tempRMSDiffEnd = Math.Sqrt(Math.Pow(tempDiffEnd, 2));
                    diffEndPhonemes[i] = tempDiffEnd;
                    rmsDiffEndPhonemes[i] = tempRMSDiffEnd;

                    uncorrLen = uncorrected[i].xmax - uncorrected[i].xmin;
                    corrLen = corrected[i].xmax - corrected[i].xmin;
                    diffLen = uncorrLen - corrLen;
                    RMSdiffLen = Math.Sqrt(Math.Pow(diffLen, 2));

                    if (i != 0) { previousPhone[i] = corrected[i - 1].text; } else { previousPhone[i] = ""; }
                    if ((i + 1) != uncorrected.Length) { followingPhone[i] = corrected[i + 1].text; } else { followingPhone[i] = ""; }

                    outputLine += corrected[i].text.Replace("\"","") + "\t";
                    outputLine += tagType + "\t";
                    outputLine += tagTypeNum + "\t";
                    outputLine += (i+1).ToString() + "\t";

                    /*Console.WriteLine("El texto corregido es: " + corrected[i].text);
                    Console.WriteLine("I es: " + i.ToString());
                    Console.WriteLine("La longitud del vector previousPhone es: " + previousPhone.Length.ToString());
                    Console.WriteLine("La segunda línea es: " + previousPhone[1]);
                    Console.WriteLine("La primera línea es: " + previousPhone[0]);*/
                    outputLine += previousPhone[i].Replace("\"","") + "\t";
                    outputLine += followingPhone[i].Replace("\"", "") + "\t";

                    outputLine += uncorrected[i].xmin.ToString() + "\t";
                    outputLine += corrected[i].xmin.ToString() + "\t";
                    outputLine += tempDiffStart.ToString() + "\t";
                    outputLine += tempRMSDiffStart.ToString() + "\t";
                    outputLine += tempRMSDiffStart / uncorrLen + "\t";

                    outputLine += uncorrected[i].xmax.ToString() + "\t";
                    outputLine += corrected[i].xmax.ToString() + "\t";
                    outputLine += tempDiffEnd.ToString() + "\t";
                    outputLine += tempRMSDiffEnd.ToString() + "\t";
                    outputLine += tempRMSDiffEnd / uncorrLen + "\t";

                    outputLine += uncorrLen.ToString() + "\t";
                    outputLine += corrLen.ToString() + "\t";

                    outputLine += diffLen.ToString() + "\t";
                    outputLine += RMSdiffLen.ToString() + "\t";
                    outputLine += RMSdiffLen / uncorrLen + "\r\n";

                }
            }

            return outputLine;

        }

        private string processRMS(string uncorrectedGrid, string correctedGrid) {

            string res = "";
            int iterador = 0;
            string intervalString = "intervals: size = ";

            string text = File.ReadAllText(uncorrectedGrid);
            string[] lines = text.Split('\n');

            //------------------------------------------------------------
            // Voy a construir dos listas, una que contenga
            // la información de los intervalos que contienen fonemas,
            // y otra que contenga la información de los intervalos
            // que contienen palabras
            //------------------------------------------------------------

            while (lines[iterador].Contains(intervalString) == false) {
                iterador++;
            }

            // Ver cuántos fonos hay en el textGrid
            string stringNumberGridsInFirstRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            int numberGridsInFirstRow = Convert.ToInt16(stringNumberGridsInFirstRow);

            // Construir la lista de intervalos para los fonemas
            interval[] uncorrectedPhonemes = new interval[numberGridsInFirstRow];
            iterador = iterador + 1;
            uncorrectedPhonemes = readTextGridIntervals(lines, iterador, numberGridsInFirstRow);

            // aquí ocupo avanzar tantos intervalos como tenga que para llegar a las palabras
            
            iterador = iterador + numberGridsInFirstRow * 4;
            // seguir pasando hasta encontrarse con item [X]:
            // Construir la lista de intervalos para las palabras
            String rowItemString = "item ["+txt_wordRow.Text.ToString()+"]";
            Console.WriteLine(lines[iterador]);
            Console.WriteLine(rowItemString);
            while (lines[iterador].Contains(rowItemString) == false) {
                iterador++;
            }

            // Construir la lista de intervalos para las palabras
            while (lines[iterador].Contains(intervalString) == false) {
                iterador++;
            }

            
            // Ver cuántas palabras hay en el textGrid
            string stringNumberGridsInSecondRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            int numberGridsInSecondRow = Convert.ToInt16(stringNumberGridsInSecondRow);

            // Leer el TextGrid para extraer las palabras
            interval[] uncorrectedWords = new interval[numberGridsInSecondRow];
            iterador = iterador + 1;
            uncorrectedWords = readTextGridIntervals(lines, iterador, numberGridsInSecondRow);

            //------------------------------------------------------------
            // Leer la lista de palabras corregidas
            //------------------------------------------------------------

            iterador = 0;
            text = File.ReadAllText(correctedGrid);
            lines = text.Split('\n');

            while (lines[iterador].Contains(intervalString) == false) {
                iterador++;
            }

            // Ver cuántos fonos hay en el textGrid
            stringNumberGridsInFirstRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            numberGridsInFirstRow = Convert.ToInt16(stringNumberGridsInFirstRow);

            // Construir la lista de intervalos para los fonemas
            interval[] correctedPhonemes = new interval[numberGridsInFirstRow];
            iterador = iterador + 1;
            correctedPhonemes = readTextGridIntervals(lines, iterador, numberGridsInFirstRow);

            // Construir la lista de intervalos para las palabras
            iterador = iterador + numberGridsInFirstRow * 4;
            // seguir pasando hasta encontrarse con item [X]:
            Console.WriteLine(lines[iterador]);
            Console.WriteLine(rowItemString);
            while (lines[iterador].Contains(rowItemString) == false) {
                iterador++;
            }

            while (lines[iterador].Contains(intervalString) == false) {
                iterador++;
            }

            // Ver cuántos fonos hay en el textGrid
            stringNumberGridsInSecondRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            numberGridsInSecondRow = Convert.ToInt16(stringNumberGridsInSecondRow);

            // Leer el TextGrid para extraer las palabras
            interval[] correctedWords = new interval[numberGridsInSecondRow];
            iterador = iterador + 1;
            correctedWords = readTextGridIntervals(lines, iterador, numberGridsInSecondRow);

            if (uncorrectedPhonemes.Length == correctedPhonemes.Length && uncorrectedWords.Length == correctedWords.Length) {

                Console.WriteLine("todos los vectores son del mismo tamaño");

                string header = "";
                header += "textoIntervalo\t";
                header += "tipoIntervalo\t";
                header += "tipoIntervaloNum\t";
                header += "numIntervalo\t";

                header += "fonoPrevio\t";
                header += "fonoSiguiente\t";

                header += "inicioAuto\t";
                header += "inicioCorr\t";
                header += "difInicio\t";
                header += "difInicioRMS\t";
                header += "difInicioPorciento\t";

                header += "finalAuto\t";
                header += "finalCorr\t";
                header += "difFinal\t";
                header += "difFinalRMS\t";
                header += "difFinalPorciento\t";

                header += "tamañoAuto\t";
                header += "tamañoCorr\t";

                header += "difTamaño\t";
                header += "difTamañoRMS\t";
                header += "difTamañoPorciento\r\n";

                res += header;
                res += calculateRMS(uncorrectedPhonemes, correctedPhonemes, "fonema", "1");
                res += calculateRMS(uncorrectedWords, correctedWords, "palabra", "2");

            }
            else {
                MessageBox.Show("Los dos TextGrids no tienen el mismo contenido. No se puede calcular la comparación:\n"+uncorrectedPhonemes.Length.ToString()+"!="+correctedPhonemes.Length.ToString()+"\n"+uncorrectedWords.Length+"!="+correctedWords.Length);
            }

            return res;

        }

        private void btn_fileDict_Click(object sender, EventArgs e)
        {
            openFileDict.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileDict.ShowDialog();

            if (result == DialogResult.OK)
            {

                txt_dict.Text = openFileDict.FileName;

            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

            if (txt_textGrid.Text.Equals("") || txt_dict.Text.Equals("") == true)
            {

                MessageBox.Show("Por favor seleccione un TextGrid y un archivo diccionario de TRES columnas para continuar");

            }
            else
            {

                string output = convertDataGrid(txt_textGrid.Text, txt_dict.Text);
                //string output = createSyllableGrid(txt_textGrid.Text, txt_dict.Text);

                string nameOutputFile = Path.GetFileNameWithoutExtension(txt_textGrid.Text);
                nameOutputFile += "-convertido.TextGrid";

                saveTextGrid.FileName = nameOutputFile;
                saveTextGrid.InitialDirectory = Path.GetDirectoryName(txt_textGrid.Text);

                DialogResult result = saveTextGrid.ShowDialog();

                if (saveTextGrid.FileName != "" && result == DialogResult.OK)
                {
                    File.WriteAllText(saveTextGrid.FileName, output);
                    MessageBox.Show("Archivo guardado");
                }

            }

        }

        private interval[] readTextGridIntervals(string[] lines, int iterador, int numberGrids) {

            interval[] res = new interval[numberGrids];
            double xmin = 0;
            double xmax = 0;

            string xminString = "xmin = ";
            string xmaxString = "xmax = ";
            string intervalTextString = "text = \"";

            string intervalText = "";

            for (int i = 0; i < numberGrids; i++) {

                if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToString().Equals(",")) {
                    xmin = Convert.ToDouble((lines[iterador + ((i * 4) + 1)].Substring((lines[iterador + ((i * 4) + 1)].IndexOf(xminString) + xminString.Length)).Replace('.', ',')));
                    xmax = Convert.ToDouble((lines[iterador + ((i * 4) + 2)].Substring((lines[iterador + ((i * 4) + 2)].IndexOf(xmaxString) + xmaxString.Length)).Replace('.', ',')));
                }
                else if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToString().Equals(".")) { 
                    xmin = Convert.ToDouble((lines[iterador + ((i * 4) + 1)].Substring((lines[iterador + ((i * 4) + 1)].IndexOf(xminString) + xminString.Length))));
                    xmax = Convert.ToDouble((lines[iterador + ((i * 4) + 2)].Substring((lines[iterador + ((i * 4) + 2)].IndexOf(xmaxString) + xmaxString.Length))));
                }   

                intervalText = lines[iterador + ((i * 4) + 3)].Substring((lines[iterador + ((i * 4) + 3)].IndexOf(intervalTextString) + intervalTextString.Length));
                intervalText = intervalText.Substring(0, intervalText.Length - 1);

                intervalText = intervalText.Replace("\" ","");

                res[i] = new interval(xmin, xmax, intervalText);

            }

            return res;

        }

        private dictWord[] buildDictionary(string fileDictionary, int needTheSylls) {

            // Codificaciones: https://msdn.microsoft.com/en-us/library/windows/desktop/dd317756(v=vs.85).aspx
            int fileEncodingDictionary = 1252;

            string dictText = File.ReadAllText(fileDictionary, Encoding.GetEncoding(fileEncodingDictionary));
            string[] dictLines = dictText.Split('\n');
            string[] dictTabElements;
            dictWord[] dictionary = new dictWord[dictLines.Length];
            string wordInSyllables = "";

            for (int i = 0; i < dictLines.Length; i++) {

                dictTabElements = dictLines[i].Split('\t');

                wordInSyllables = dictTabElements[2].Trim('\n', '\r');

                if ( needTheSylls == 0 ) {
                    wordInSyllables = wordInSyllables.Replace(". ", "");
                }

                dictionary[i] = new dictWord(dictTabElements[0], dictTabElements[1], wordInSyllables);

            }

            return dictionary;

        }

        private readTextGrid processPhonemesWords(string fileTextGrid) {

            int iterador = 0;
            string intervalString = "intervals: size = ";

            string textGridPhonemesHeader = "";
            string textGridWordsHeader = "";

            string text = File.ReadAllText(fileTextGrid);
            string[] lines = text.Split('\n');

            while (lines[iterador].Contains(intervalString) == false) {
                textGridPhonemesHeader += lines[iterador] + "\n";
                iterador++;
            }
            textGridPhonemesHeader += lines[iterador] + "\n";

            // Ver cuántos fonos hay en el textGrid
            //Console.WriteLine(lines[iterador]);
            string stringNumberGridsInFirstRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            int numberGridsInFirstRow = Convert.ToInt16(stringNumberGridsInFirstRow);

            // Construir la lista de intervalos para los fonemas
            interval[] phonemes = new interval[numberGridsInFirstRow];
            iterador = iterador + 1;
            phonemes = readTextGridIntervals(lines, iterador, numberGridsInFirstRow);
            Console.WriteLine(phonemes.Length.ToString());

            // Construir la lista de intervalos para las palabras

            // Encontrar la línea que marca el inicio de los intervalos
            // que contienen las palabras

            iterador = iterador + numberGridsInFirstRow * 4;

            while (lines[iterador].Contains(intervalString) == false) {
                //Console.WriteLine(iterador.ToString());
                textGridWordsHeader += lines[iterador] + "\n";
                iterador++;
            }
            textGridWordsHeader += lines[iterador] + "\n";

            // Ver cuántos fonos hay en el textGrid
            //Console.WriteLine(lines[iterador]);
            string stringNumberGridsInSecondRow = lines[iterador].Substring((lines[iterador].IndexOf(intervalString) + intervalString.Length));
            int numberGridsInSecondRow = Convert.ToInt16(stringNumberGridsInSecondRow);

            // Leer el TextGrid para extraer las palabras
            interval[] words = new interval[numberGridsInSecondRow];
            iterador = iterador + 1;
            words = readTextGridIntervals(lines, iterador, numberGridsInSecondRow);

            readTextGrid retItems = new readTextGrid(phonemes, words, textGridPhonemesHeader, textGridWordsHeader);

            return retItems;

        }

        private List<interval> createSyllableIntervals( List<interval> phonemes, string[] word ) {

            List<interval> res = new List<interval>();

            double startTime = 0;
            startTime = phonemes[0].xmin;

            double endTime = 0;
            int iterador = 0;
            string tempSyllable = "";

            int dotsFound = 0;

            while (iterador < word.Length) {

                    if (word[iterador].Equals(".") == false) {
                        Console.WriteLine(iterador.ToString() + "-" + word.Length + ": " + word[iterador]);
                        tempSyllable += phonemes[iterador-dotsFound].text;
                        endTime = phonemes[iterador-dotsFound].xmax;
                        iterador += 1;
                    }
                    else {
                        Console.WriteLine(iterador.ToString() + "-" + word.Length + ": " + word[iterador]);
                        res.Add(new interval(startTime, endTime, tempSyllable));
                        tempSyllable = phonemes[iterador-dotsFound].text;
                        startTime = phonemes[iterador-dotsFound].xmin;
                        endTime = phonemes[iterador-dotsFound].xmax;
                        dotsFound += 1;
                        iterador += 2;
                   
                }

            }

            res.Add(new interval(startTime, endTime, tempSyllable));

            for (int i = 0; i < phonemes.Count; i++) {
                Console.WriteLine(phonemes[i].text);
            }

            for (int i = 0; i < word.Length; i++) { 
                Console.WriteLine(word[i]);
            }

            for (int i = 0; i < res.Count(); i++) {
                Console.WriteLine(res[i].text + ": " + res[i].xmin + ", " + res[i].xmax);
            }


            return res;

        }

        private List<interval> addBlankSyllables( List<interval> sylls, double duration ) {

            List<interval> res = new List<interval>();

            if ( sylls[0].xmin > 0 ) {
                res.Add(new interval(0, sylls[0].xmin, "sp"));
            }

            for (int i = 0; i < (sylls.Count-1); i++) {

                if (sylls[i + 1].xmin != sylls[i].xmax) {
                    res.Add(new interval(sylls[i].xmax, sylls[i + 1].xmin, "sp"));
                }

                res.Add(sylls[i]);

            }

            if (sylls[0].xmax < duration) {
                res.Add(new interval(sylls[sylls.Count-1].xmax, duration, "sp"));
            }

            return res;

        }

        private string createSyllableGrid(string fileTextGrid, string fileDictionary) {

            string res = "";

            //------------------------------------------------------------
            // Primero, voy a construir el diccionario. Este contiene
            // las palabras en ortografía normal, en arpabet, y en 
            // los fonos que queremos en el textGrid
            //------------------------------------------------------------

            dictWord[] dictionary = buildDictionary(fileDictionary, 1);

            //------------------------------------------------------------
            // Luego, voy a construir dos listas, una que contenga
            // la información de los intervalos que contienen fonemas,
            // y otra que contenga la información de los intervalos
            // que contienen palabras
            //------------------------------------------------------------

            readTextGrid filecontents = processPhonemesWords(fileTextGrid);
            interval[] phonemes = filecontents.phonemes;
            interval[] words = filecontents.words;
            string textGridPhonemesHeader = filecontents.phonemeHeader;
            string textGridWordsHeader = filecontents.wordHeader;
            int numberGridsInFirstRow = phonemes.Count();
            int numberGridsInSecondRow = words.Count();

            List<interval> syllables = new List<interval>();
            List<interval> tempPhonemes = new List<interval>();
            List<interval> tempSylls = new List<interval>();

            //------------------------------------------------------------
            // d
            //------------------------------------------------------------

            double currentWordXmin = 0;
            double currentWordXmax = 0;
            string currentWord = "";
            string[] currentWordOutputVector = new string[0];
            string[] currentWordOutputVectorWithoutDots = new string[0];
            string currentWordOutputWithDots = "";
            string currentWordOutputWithoutDots = "";
            string currentWordJoinedArpabet = "";
            string iteratingWordJoinedArpabet = "";
            List<int> intervalPosition = new List<int>();

            for (int i = 0; i < numberGridsInSecondRow; i++) {

                tempSylls = new List<interval>();
                tempPhonemes = new List<interval>();

                if (words[i].text.Equals("sp") == false && words[i].text.Equals("_") == false && words[i].text.Equals("") == false) {

                    intervalPosition = new List<int>();
                    currentWordOutputVector = new string[0];
                    currentWordOutputVectorWithoutDots = new string[0];
                    currentWordOutputWithoutDots = "";
                    currentWordOutputWithDots = "";
                    iteratingWordJoinedArpabet = "";
                    currentWord = words[i].text;
                    currentWordXmin = words[i].xmin;
                    currentWordXmax = words[i].xmax;

                    // Encontrar la palabra en el diccionario
                    for (int j = 0; j < dictionary.Length; j++) {
                        if (dictionary[j].word.ToLower().Equals(currentWord.ToLower()) == true)
                        {
                            currentWordOutputVector = dictionary[j].outputLetters;
                            currentWordJoinedArpabet = dictionary[j].wordArpabet;
                            currentWordOutputWithDots = dictionary[j].wordOutput;
                            currentWordOutputWithoutDots = dictionary[j].wordOutput.Replace(".", "");
                            currentWordOutputVectorWithoutDots = dictionary[j].outputLettersWithoutDots;
                        }
                    }

                    // Encontrar los índices de los intervalos que corresponden a los
                    // fonemas de la palabra actual
                    for (int j = 0; j < numberGridsInFirstRow; j++)
                    {
                        if (phonemes[j].xmin >= currentWordXmin && phonemes[j].xmax <= currentWordXmax)
                        {
                            intervalPosition.Add(j);
                            iteratingWordJoinedArpabet += phonemes[j].text;
                        }
                    }

                    // cambiar las letras arpabet en eltextgrid por las letras que queremos
                    //if (currentWordJoinedArpabet.ToLower().Equals(iteratingWordJoinedArpabet.ToLower()) == true && currentWordOutputVectorWithoutDots.Length == intervalPosition.Count) {
                    if (currentWordOutputWithoutDots.ToLower().Equals(iteratingWordJoinedArpabet.ToLower()) == true && currentWordOutputVectorWithoutDots.Length == intervalPosition.Count) {

                            for (int j = 0; j < intervalPosition.Count; j++) {
                            tempPhonemes.Add(phonemes[intervalPosition[j]]);
                        }

                        tempSylls = createSyllableIntervals(tempPhonemes, currentWordOutputVector);

                        for (int k = 0; k < tempSylls.Count; k++) {
                            syllables.Add(tempSylls[k]);
                        }
                        
                    }
                    else
                    {
                        Console.Write("Hubo un error al tratar de alinear " + currentWord + "porque ");
                        if (currentWordJoinedArpabet.Equals(iteratingWordJoinedArpabet) == false)
                        {
                            Console.Write(" la palabra arpabet ( " + currentWordJoinedArpabet + " ) no es igual a la palabra actual (" + iteratingWordJoinedArpabet + ")\n");
                        }
                        if (currentWordOutputWithoutDots.Length != intervalPosition.Count)
                        {
                            Console.Write(" el vector de salida es " + currentWordOutputWithoutDots + ", que mide " + currentWordOutputWithoutDots.Length.ToString() + ", y el numero de intervalos es " + intervalPosition.Count.ToString() + ")\n");
                        }
                        /*if (currentWordOutputVector.Length != intervalPosition.Count) {
                            Console.Write(" las palabras tienen diferente número de letras\n");
                        }*/
                    }

                    Console.WriteLine("\n");

                }


            }

            syllables = addBlankSyllables(syllables, phonemes[phonemes.Count()-1].xmax);

            textGridPhonemesHeader = textGridPhonemesHeader.Replace("size = 2", "size = 3");
            textGridWordsHeader = textGridWordsHeader.Replace("item [2]", "item [3]");

            string textGridSyllHeader = "\titem [2]:\r";
            textGridSyllHeader += "\t\tclass = \"IntervalTier\"\r";
            textGridSyllHeader += "\t\tname = \"sylls\"\r";
            textGridSyllHeader += "\t\txmin = 0.000000\r";
            textGridSyllHeader += "\t\txmax = " + (phonemes[phonemes.Count() - 1].xmax).ToString().Replace(',','.') + "\r";
            textGridSyllHeader += "\t\tintervals: size = " + syllables.Count + "\r";

            res = textGridPhonemesHeader;
            res += printPraatIntervals(numberGridsInFirstRow, phonemes);
            res += textGridSyllHeader;
            res += printPraatIntervalsFromLists(syllables.Count, syllables);
            res += textGridWordsHeader;
            res += printPraatIntervals(numberGridsInSecondRow, words);

            return res;

        }

    private string printPraatIntervalsFromLists(int numberRows, List<interval> items) {

            string res = "";

            interval[] temp = new interval[items.Count];

            for ( int i = 0; i < items.Count; i++ ) {
                temp[i] = items[i];
            }

            res = printPraatIntervals(numberRows, temp);

            return res;

        }

    private string printPraatIntervals(int numberRows, interval[] items) {

        string res = "";

        for (int i = 0; i < numberRows; i++) {
                res += "\t\t\t" + "intervals [" + (i + 1).ToString() + "]:\n";
                res += "\t\t\t\t" + "xmin = " + items[i].xmin.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "xmax = " + items[i].xmax.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "text = \"" + items[i].text + "\"\n";
        }

        return res;

    }

        private string convertDataGrid(string fileTextGrid, string fileDictionary) {

            string res = "";
            
            //------------------------------------------------------------
            // Primero, voy a construir el diccionario. Este contiene
            // las palabras en ortografía normal, en arpabet, y en 
            // los fonos que queremos en el textGrid
            //------------------------------------------------------------

            dictWord[] dictionary = buildDictionary(fileDictionary, 0);

            //------------------------------------------------------------
            // Luego, voy a construir dos listas, una que contenga
            // la información de los intervalos que contienen fonemas,
            // y otra que contenga la información de los intervalos
            // que contienen palabras
            //------------------------------------------------------------

            readTextGrid filecontents = processPhonemesWords(fileTextGrid);
            interval[] phonemes = filecontents.phonemes;
            interval[] words = filecontents.words;
            string textGridPhonemesHeader = filecontents.phonemeHeader;
            string textGridWordsHeader = filecontents.wordHeader;
            int numberGridsInFirstRow = phonemes.Count();
            int numberGridsInSecondRow = words.Count();

            //------------------------------------------------------------
            //------------------------------------------------------------

            // para cada palabra, buscar todos los fonemas que están dentro de ese índice de tiempo

            // buscar los índices de tiempo en los que ocurre una palabra (puede ocurrir varias veces en el texto)

            double currentWordXmin = 0;
            double currentWordXmax = 0;
            string currentWord = "";
            string[] currentWordOutputVector = new string[0];
            string currentWordJoinedArpabet = "";
            string iteratingWordJoinedArpabet = "";
            List<int> intervalPosition = new List<int>();

            for (int i = 0; i < numberGridsInSecondRow; i++) {

                if (words[i].text.Equals("sp") == false && words[i].text.Equals("_") ==false && words[i].text.Equals("") == false) {

                    intervalPosition = new List<int>();
                    currentWordOutputVector = new string[0];
                    iteratingWordJoinedArpabet = "";
                    currentWord = words[i].text;
                    currentWordXmin = words[i].xmin;
                    currentWordXmax = words[i].xmax;

                    // Encontrar la palabra en el diccionario
                    for (int j = 0; j < dictionary.Length; j++) {
                        if (dictionary[j].word.ToLower().Equals(currentWord.ToLower()) == true) {
                            currentWordOutputVector = dictionary[j].outputLetters;
                            currentWordJoinedArpabet = dictionary[j].wordArpabet;
                        }
                    }

                    // Encontrar los índices de los intervalos que corresponden a los
                    // fonemas de la palabra actual
                    for (int j = 0; j < numberGridsInFirstRow; j++) {
                        if (phonemes[j].xmin >= currentWordXmin && phonemes[j].xmax <= currentWordXmax) {
                            intervalPosition.Add(j);
                            iteratingWordJoinedArpabet += phonemes[j].text;
                        }
                    }

                    // cambiar las letras arpabet en eltextgrid por las letras que queremos
                    if (currentWordJoinedArpabet.ToLower().Equals(iteratingWordJoinedArpabet.ToLower()) == true && currentWordOutputVector.Length == intervalPosition.Count)
                    {
                        for (int j = 0; j < intervalPosition.Count; j++)
                        {
                            phonemes[intervalPosition[j]].text = currentWordOutputVector[j];
                        }
                    }
                    else
                    {
                        Console.Write("Hubo un error al tratar de alinear " + currentWord + "porque ");
                        if (currentWordJoinedArpabet.Equals(iteratingWordJoinedArpabet) == false)
                        {
                            Console.Write(" la palabra arpabet ( " + currentWordJoinedArpabet + " ) no es igual a la palabra actual (" + iteratingWordJoinedArpabet + ")\n");
                        }
                        /*if (currentWordOutputVector.Length != intervalPosition.Count) {
                            Console.Write(" las palabras tienen diferente número de letras\n");
                        }*/
                    }

                }


            }

            res = textGridPhonemesHeader;

            // Construir los intervalos de los fonemas
            for (int i = 0; i < numberGridsInFirstRow; i++)
            {
                res += "\t\t\t" + "intervals [" + (i + 1).ToString() + "]:\n";
                res += "\t\t\t\t" + "xmin = " + phonemes[i].xmin.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "xmax = " + phonemes[i].xmax.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "text = \"" + phonemes[i].text + "\"\n";
            }

            res += textGridWordsHeader;

            for (int i = 0; i < numberGridsInSecondRow; i++)
            {
                res += "\t\t\t" + "intervals [" + (i + 1).ToString() + "]:\n";
                res += "\t\t\t\t" + "xmin = " + words[i].xmin.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "xmax = " + words[i].xmax.ToString().Replace(',', '.') + "\n";
                res += "\t\t\t\t" + "text = \"" + words[i].text + "\"\n";
            }

            //Console.WriteLine(res);

            return res;

        }

        private void txt_dict_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_textGrid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_openUncorrectedTextGrid_Click(object sender, EventArgs e)
        {

            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK)
            {
                txt_TextGridUncorrected.Text = openFileTextGrid.FileName;
            }

        }

        public class readTextGrid {

            public interval[] phonemes { get; set; }
            public interval[] words { get; set;  }

            public string phonemeHeader { get; set; }
            public string wordHeader { get; set; }

            public readTextGrid(interval[] inPhonemes, interval[] inWords, string inPhonemeHeader, string inWordHeader) {
                phonemes = inPhonemes;
                words = inWords;
                phonemeHeader = inPhonemeHeader;
                wordHeader = inWordHeader;
            }

        }

        public class interval
        {

            public double xmin { get; set; }
            public double xmax { get; set; }
            public string text { get; set; }
            public interval() { }

            public interval(double inXmin, double inXmax, string inText)
            {
                xmin = inXmin;
                xmax = inXmax;
                text = inText;
            }

        }

        public class dictWord
        {

            public string word { get; set; }
            public string[] arpabetLetters { get; set; }
            public string[] outputLetters { get; set; }
            public string[] outputLettersWithoutDots { get; set; }
            public string wordArpabet { get; set; }
            public string wordOutput { get; set; }

            public dictWord() { }

            public dictWord(string inWord, string inArpabet, string inOutput) {

                string tempOutput = inOutput.Replace(". ", "");

                word = inWord;

                arpabetLetters = inArpabet.Split(' ');
                outputLetters = inOutput.Split(' ');

                wordArpabet = inArpabet.Replace(" ", "");
                wordOutput = inWord.Replace(" ", "");

                outputLettersWithoutDots = tempOutput.Split(' ');

            }

        }

        private void btn_openHandCorrectedTextGrid_Click(object sender, EventArgs e) {

            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK) {
                txt_textGridHandCorrected.Text = openFileTextGrid.FileName;
            }

        }

        private void btn_RMSCalc_Click(object sender, EventArgs e) {

            if (txt_TextGridUncorrected.Text.Equals("") || txt_textGridHandCorrected.Text.Equals("") == true) {
                MessageBox.Show("Por favor seleccione dos TextGrids para continuar");
            }
            else {

                string output = processRMS(txt_TextGridUncorrected.Text, txt_textGridHandCorrected.Text);

                string nameOutputFile = Path.GetFileNameWithoutExtension(txt_TextGridUncorrected.Text);
                nameOutputFile += "-rms.txt";

                saveTextGrid.FileName = nameOutputFile;
                saveTextGrid.InitialDirectory = Path.GetDirectoryName(txt_TextGridUncorrected.Text);

                DialogResult result = saveTextGrid.ShowDialog();

                if (saveTextGrid.FileName != "" && result == DialogResult.OK) {
                    File.WriteAllText(saveTextGrid.FileName, output);
                    MessageBox.Show("Archivo guardado");
                }

                //Console.WriteLine(output);

            }
        }

        private void btn_file_syll_textgrid_Click(object sender, EventArgs e)
        {
            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK) {
                txt_syll_textgrid.Text = openFileTextGrid.FileName;
            }
        }

        private void btn_file_sylls_dict_Click(object sender, EventArgs e) { 

            openFileDict.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileDict.ShowDialog();

            if (result == DialogResult.OK) {
                txt_syll_dict.Text = openFileDict.FileName;
            }

        }

        private void btn_add_sylls_Click(object sender, EventArgs e) {

            if (txt_syll_textgrid.Text.Equals("") || txt_syll_dict.Text.Equals("") == true) {
                MessageBox.Show("Por favor seleccione un TextGrid y un archivo diccionario de TRES columnas para continuar");
            }
            else {

                string output = createSyllableGrid(txt_syll_textgrid.Text, txt_syll_dict.Text);

                string nameOutputFile = Path.GetFileNameWithoutExtension(txt_syll_textgrid.Text);
                nameOutputFile += "-convertido.TextGrid";

                saveTextGrid.FileName = nameOutputFile;
                saveTextGrid.InitialDirectory = Path.GetDirectoryName(txt_syll_textgrid.Text);

                DialogResult result = saveTextGrid.ShowDialog();

                if (saveTextGrid.FileName != "" && result == DialogResult.OK)
                {
                    File.WriteAllText(saveTextGrid.FileName, output);
                    MessageBox.Show("Archivo guardado");
                }

            }

        }

        private void btn_abrirArchivoNasalidad_Click(object sender, EventArgs e) {

            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK) {
                txt_input_nasalidad.Text = openFileTextGrid.FileName;
            }


        }

        private string tipoLetraMephaa(string letra) {

            string res = "";

            if (letra.Equals("a")) { res += "vocal"; }
            else if (letra.Equals("a'")) { res += "vocal"; }
            else if (letra.Equals("aa")) { res += "vocal"; }
            else if (letra.Equals("an")) { res += "vocal"; }
            else if (letra.Equals("aà")) { res += "vocal"; }
            else if (letra.Equals("b")) { res += "consonante"; }
            else if (letra.Equals("p")) { res += "consonante"; }
            else if (letra.Equals("d")) { res += "consonante"; }
            else if (letra.Equals("dx")) { res += "consonante"; }
            else if (letra.Equals("e")) { res += "vocal"; }
            else if (letra.Equals("een")) { res += "vocal"; }
            else if (letra.Equals("en")) { res += "vocal"; }
            else if (letra.Equals("g")) { res += "consonante"; }
            else if (letra.Equals("i")) { res += "vocal"; }
            else if (letra.Equals("i'")) { res += "vocal"; }
            else if (letra.Equals("ii")) { res += "vocal"; }
            else if (letra.Equals("iin")) { res += "vocal"; }
            else if (letra.Equals("in")) { res += "vocal"; }
            else if (letra.Equals("in'")) { res += "vocal"; }
            else if (letra.Equals("iy")) { res += "semiconsonante"; }
            else if (letra.Equals("j")) { res += "consonante"; }
            else if (letra.Equals("k")) { res += "consonante"; }
            else if (letra.Equals("kh")) { res += "consonante"; }
            else if (letra.Equals("l")) { res += "consonante"; }
            else if (letra.Equals("m")) { res += "consonante"; }
            else if (letra.Equals("n")) { res += "consonante"; }
            else if (letra.Equals("o")) { res += "vocal"; }
            else if (letra.Equals("oo")) { res += "vocal"; }
            else if (letra.Equals("r")) { res += "consonante"; }
            else if (letra.Equals("s")) { res += "consonante"; }
            else if (letra.Equals("sp")) { res += "silencio"; }
            else if (letra.Equals("-")) { res += "silencio"; }
            else if (letra.Equals("t")) { res += "consonante"; }
            else if (letra.Equals("th")) { res += "consonante"; }
            else if (letra.Equals("u")) { res += "vocal"; }
            else if (letra.Equals("u'")) { res += "vocal"; }
            else if (letra.Equals("uu")) { res += "vocal"; }
            else if (letra.Equals("uun")) { res += "vocal"; }
            else if (letra.Equals("uw")) { res += "semiconsonante"; }
            else if (letra.Equals("v")) { res += "consonante"; }
            else if (letra.Equals("x")) { res += "consonante"; }
            else if (letra.Equals("y")) { res += "consonante"; }
            else if (letra.Equals("à")) { res += "vocal"; }
            else if (letra.Equals("à'")) { res += "vocal"; }
            else if (letra.Equals("àn")) { res += "vocal"; }
            else if (letra.Equals("àà")) { res += "vocal"; }
            else if (letra.Equals("àá")) { res += "vocal"; }
            else if (letra.Equals("á")) { res += "vocal"; }
            else if (letra.Equals("á'")) { res += "vocal"; }
            else if (letra.Equals("áa")) { res += "vocal"; }
            else if (letra.Equals("án'")) { res += "vocal"; }
            else if (letra.Equals("é")) { res += "vocal"; }
            else if (letra.Equals("ì")) { res += "vocal"; }
            else if (letra.Equals("ì'")) { res += "vocal"; }
            else if (letra.Equals("ìn")) { res += "vocal"; }
            else if (letra.Equals("ìí")) { res += "vocal"; }
            else if (letra.Equals("í")) { res += "vocal"; }
            else if (letra.Equals("í'")) { res += "vocal"; }
            else if (letra.Equals("íin")) { res += "vocal"; }
            else if (letra.Equals("ñ")) { res += "consonante"; }
            else if (letra.Equals("òón")) { res += "vocal"; }
            else if (letra.Equals("ón'")) { res += "vocal"; }
            else if (letra.Equals("óó")) { res += "vocal"; }
            else if (letra.Equals("ù")) { res += "vocal"; }
            else if (letra.Equals("ùn'")) { res += "vocal"; }
            else if (letra.Equals("ùù")) { res += "vocal"; }
            else if (letra.Equals("ùú")) { res += "vocal"; }
            else if (letra.Equals("ú")) { res += "vocal"; }
            else if (letra.Equals("ú'")) { res += "vocal"; }
            else if (letra.Equals("úun")) { res += "vocal"; }
            else if (letra.Equals("úú")) { res += "vocal"; }
            else if (letra.Equals("ch")) { res += "consonante"; }
            else if (letra.Equals("an'")) { res += "vocal"; }
            else if (letra.Equals("e'")) { res += "vocal"; }
            else if (letra.Equals("ee")) { res += "vocal"; }
            else if (letra.Equals("f")) { res += "consonante"; }
            else if (letra.Equals("o'")) { res += "vocal"; }
            else if (letra.Equals("oò")) { res += "vocal"; }
            else if (letra.Equals("ph")) { res += "consonante"; }
            else if (letra.Equals("un")) { res += "vocal"; }
            else if (letra.Equals("un'")) { res += "vocal"; }
            else if (letra.Equals("uù")) { res += "vocal"; }
            else if (letra.Equals("ààn")) { res += "vocal"; }
            else if (letra.Equals("án")) { res += "vocal"; }
            else if (letra.Equals("áá")) { res += "vocal"; }
            else if (letra.Equals("è")) { res += "vocal"; }
            else if (letra.Equals("èn")) { res += "vocal"; }
            else if (letra.Equals("èèn")) { res += "vocal"; }
            else if (letra.Equals("ée")) { res += "vocal"; }
            else if (letra.Equals("éen")) { res += "vocal"; }
            else if (letra.Equals("ìi")) { res += "vocal"; }
            else if (letra.Equals("ìin")) { res += "vocal"; }
            else if (letra.Equals("ìn'")) { res += "vocal"; }
            else if (letra.Equals("ìín")) { res += "vocal"; }
            else if (letra.Equals("íi")) { res += "vocal"; }
            else if (letra.Equals("ín")) { res += "vocal"; }
            else if (letra.Equals("ín'")) { res += "vocal"; }
            else if (letra.Equals("íí")) { res += "vocal"; }
            else if (letra.Equals("íí'")) { res += "vocal"; }
            else if (letra.Equals("íín")) { res += "vocal"; }
            else if (letra.Equals("ò")) { res += "vocal"; }
            else if (letra.Equals("óo")) { res += "vocal"; }

            else if (letra.Equals("oó")) { res += "vocal"; }

            else if (letra.Equals("óón")) { res += "vocal"; }
            else if (letra.Equals("ù'")) { res += "vocal"; }
            else if (letra.Equals("ùn")) { res += "vocal"; }
            else if (letra.Equals("ùún")) { res += "vocal"; }
            else if (letra.Equals("ún")) { res += "vocal"; }
            else if (letra.Equals("úu")) { res += "vocal"; }
            else if (letra.Equals("úú'")) { res += "vocal"; }
            else if (letra.Equals("úún")) { res += "vocal"; }

            else if (letra.Equals("áán")) { res += "vocal"; }
            else if (letra.Equals("ón")) { res += "vocal"; }
            else if (letra.Equals("óon")) { res += "vocal"; }
            else if (letra.Equals("óó'")) { res += "vocal"; }
            else if (letra.Equals("é'")) { res += "vocal"; }

            else if (letra.Equals("è'")) { res += "vocal"; }
            else if (letra.Equals("én")) { res += "vocal"; }
            else if (letra.Equals("ùú'")) { res += "vocal"; }
            else if (letra.Equals("èè'")) { res += "vocal"; }
            else if (letra.Equals("òó")) { res += "vocal"; }

            else if (letra.Equals("àán")) { res += "vocal"; }
            else if (letra.Equals("àán'")) { res += "vocal"; }
            else if (letra.Equals("áá'")) { res += "vocal"; }
            else if (letra.Equals("àán")) { res += "vocal"; }
            else if (letra.Equals("aàn")) { res += "vocal"; }
            else if (letra.Equals("áá'")) { res += "vocal"; }
            else if (letra.Equals("iìn")) { res += "vocal"; }
            else if (letra.Equals("iì")) { res += "vocal"; }
            else if (letra.Equals("ó")) { res += "vocal"; }
            else if (letra.Equals("òò")) { res += "vocal"; }
            else if (letra.Equals("óón'")) { res += "vocal"; }
            else if (letra.Equals("ó'")) { res += "vocal"; }
            else if (letra.Equals("uu'")) { res += "vocal"; }
            else if (letra.Equals("ii'")) { res += "vocal"; }
            else if (letra.Equals("èè")) { res += "vocal"; }
            else if (letra.Equals("íín'")) { res += "vocal"; }
            else if (letra.Equals("rr")) { res += "consonante"; }
            else if (letra.Equals("àn'")) { res += "vocal"; }
            else if (letra.Equals("úún")) { res += "vocal"; }

            else { res += "ERR"; }

            return res;

        }

        private void btn_generarNasalidad_Click(object sender, EventArgs e) {

            if (txt_input_nasalidad.Text.Equals("") == true) {
                MessageBox.Show("Por favor seleccione un TextGrid y un archivo diccionario de TRES columnas para continuar");
            }
            else {

                string output = generarTextGridNasal(txt_input_nasalidad.Text);

                string nameOutputFile = Path.GetFileNameWithoutExtension(txt_input_nasalidad.Text);
                nameOutputFile += "-nasal.TextGrid";

                saveTextGrid.FileName = nameOutputFile;
                saveTextGrid.InitialDirectory = Path.GetDirectoryName(txt_input_nasalidad.Text);

                DialogResult result = saveTextGrid.ShowDialog();

                if (saveTextGrid.FileName != "" && result == DialogResult.OK)
                {
                    File.WriteAllText(saveTextGrid.FileName, output);
                    MessageBox.Show("Archivo guardado");
                }

            }


            //readTextGrid filecontents = processPhonemesWords(fileTextGrid);

        }

        private string enlazarSonidosPalabrasNasales(string filename, string sonidos) {

            string res = "";

            //---------------------------
            // first, read the TextGrid
            //---------------------------

            Console.WriteLine(filename);

            readTextGrid filecontents = processPhonemesWords(filename);
            interval[] phonemes = filecontents.phonemes;
            interval[] words = filecontents.words;

            //----------------------------------
            // second, read the nasal phonemes
            //----------------------------------

            string lineasSinSeparar = sonidos;
            string[] lineas = lineasSinSeparar.Split('\n');

            for ( int i = 0; i < lineas.Count(); i++ ) {

                string[] fonemasTiempo = lineas[i].Split('\t');
                double tiempoFonema = Convert.ToDouble(fonemasTiempo[1]);

                for ( int j = 0; j < words.Count(); j++ ) {
                    
                    if ( tiempoFonema >= words[j].xmin && tiempoFonema <= words[j].xmax ) {
                        res += fonemasTiempo[0] + "\t" + words[j].text + "\r\n";
                    }

                }

            }

            //string textGridPhonemesHeader = filecontents.phonemeHeader;
            //string textGridWordsHeader = filecontents.wordHeader;
            //int numberGridsInFirstRow = phonemes.Count();
            //int numberGridsInSecondRow = words.Count();

            //List<string> wordsInNasalWordTier = new List<string>();
            //string tempPalabra = "";

            /*for (int i = 0; i < phonemes.Count(); i++) {

                for (int j = 0; j < words.Count(); j++) {
                    if (tempPalabra == "" && phonemes[i].xmin >= words[j].xmin && phonemes[i].xmax <= words[j].xmax) {
                        tempPalabra = words[j].text;
                    }
                }*/

                //wordsInNasalWordTier.Add(tempPalabra);
                //tempPalabra = "";

            //}

            return res;

        }

        private string generarTextGridNasal(string filename) {

            string res = "";

            //-------------------------------------------------------------------------
            // Primer paso: construir una lista de todos los intervalos de fonemas,
            // y de la palabra correspondiente a cada intervalo
            //-------------------------------------------------------------------------

            readTextGrid filecontents = processPhonemesWords(filename);

            interval[] phonemes = filecontents.phonemes;
            interval[] words = filecontents.words;
            string textGridPhonemesHeader = filecontents.phonemeHeader;
            string textGridWordsHeader = filecontents.wordHeader;
            int numberGridsInFirstRow = phonemes.Count();
            int numberGridsInSecondRow = words.Count();

            List<string> wordsInNasalWordTier = new List<string>();
            string tempPalabra = "";
            
            for ( int i = 0; i < phonemes.Count(); i++ ) {

                for ( int j = 0; j < words.Count(); j++ ) {
                    if ( tempPalabra == "" && phonemes[i].xmin >= words[j].xmin && phonemes[i].xmax <= words[j].xmax ) {
                        tempPalabra = words[j].text;
                    }
                }

                wordsInNasalWordTier.Add(tempPalabra);
                tempPalabra = "";                

            }

            //----------------------------------------------------------------------------
            // Segundo, construir una nueva lista de intervalos, en la que solo aparezcan
            // vocales y espacios en blanco
            //----------------------------------------------------------------------------

            List<interval> nasalPhonemes = new List<interval>();
            List<interval> nasalWords = new List<interval>();
            interval tempIntervalo = new interval();
            double tempXMin = 0;
            double tempXMax = 0;
            string tempTexto = "";
            int salirDelCicloConsonantes = 0;
            int intervalosALaDerechaDelIterador = 1;

            for ( int i = 0; i < phonemes.Count(); i++ ) {

                if (tipoLetraMephaa(phonemes[i].text) == "vocal") {
                    nasalPhonemes.Add(phonemes[i]);
                    //Console.WriteLine("1. " + phonemes[i].xmin.ToString() + "\t-\t" + phonemes[i].text);
                }
                else {

                    if ( i+1 < phonemes.Count() ) {

                        if (tipoLetraMephaa(phonemes[i + intervalosALaDerechaDelIterador].text) == "vocal") {
                            tempIntervalo = new interval(phonemes[i].xmin, phonemes[i].xmax, "");
                            nasalPhonemes.Add(tempIntervalo);
                            //Console.WriteLine("2. " + phonemes[i].xmin.ToString() + "\t-\t" + phonemes[i].xmax.ToString() + "\t-\t" + phonemes[i].text);
                        }
                        else {

                            tempXMin = phonemes[i].xmin;
                            tempXMax = phonemes[i].xmax;
                            intervalosALaDerechaDelIterador++;

                            while ( salirDelCicloConsonantes == 0 && i+ intervalosALaDerechaDelIterador < phonemes.Count()) {

                                if (tipoLetraMephaa(phonemes[i + intervalosALaDerechaDelIterador].text) == "vocal") {
                                    tempXMax = phonemes[i + intervalosALaDerechaDelIterador - 1].xmax;
                                    tempIntervalo = new interval(tempXMin, tempXMax, "");
                                    nasalPhonemes.Add(tempIntervalo);
                                    salirDelCicloConsonantes = 1;
                                    //Console.WriteLine("3. " + tempXMin.ToString() + "\t-\t" + tempXMax.ToString());
                                }
                                else {
                                    intervalosALaDerechaDelIterador++;
                                }

                            }

                            i = i + intervalosALaDerechaDelIterador - 1;
                            salirDelCicloConsonantes = 0;
                            intervalosALaDerechaDelIterador = 1;

                        }
                        
                    }
                    else {

                        // intervalo final, y si llegué aquí es pq el intervalo final no es una vocal

                        tempIntervalo = new interval(phonemes[i].xmin, phonemes[i].xmax, "");
                        nasalPhonemes.Add(tempIntervalo);

                        //Console.WriteLine("**** topé con el intervalo final **** ");
                    }

                }

            }

            tempIntervalo = new interval(nasalPhonemes[nasalPhonemes.Count()-1].xmax, phonemes[phonemes.Count() - 1].xmax, "");
            nasalPhonemes.Add(tempIntervalo);

            //----------------------------------------------------------------------------
            // Tercero, construir una nueva de lista de intervalos, basada en la anterior
            // en la que solo aparezcan palabras y espacios en blanco
            //----------------------------------------------------------------------------

            string tempPalabraNasal = "";

            for ( int i = 0; i < nasalPhonemes.Count(); i++ ) {
                tempPalabraNasal = "";
                if (nasalPhonemes[i].text != "" ) {
                    for (int j = 0; j < words.Count(); j++) {
                        if (nasalPhonemes[i].xmin >= words[j].xmin && nasalPhonemes[i].xmax <= words[j].xmax) {
                            tempPalabraNasal = words[j].text;
                        }
                    }
                }
                nasalWords.Add(new interval(nasalPhonemes[i].xmin, nasalPhonemes[i].xmax, tempPalabraNasal));
            }

            //----------------------------------------------------------------------------
            // Cuarto, formatear estas dos listas como un TextGrid de Praat
            //----------------------------------------------------------------------------

            string newHeader = "File type = \"ooTextFile\"\r";
            newHeader       += "Object class = \"TextGrid\"\r";
            newHeader       += "xmin = 0\r";
            newHeader       += "xmax = " + (phonemes[phonemes.Count() - 1].xmax).ToString().Replace(',', '.') + "\r";
            newHeader       += "tiers? <exists>\r";
            newHeader       += "size = 2\r";
            newHeader       += "item []:\r";
            newHeader       += "\titem [1]:\r";
            newHeader       += "\t\tclass = \"IntervalTier\"\r";
            newHeader       += "\t\tname = \"phon\"\r";
            newHeader       += "\t\txmin = 0\r";
            newHeader       += "\t\txmax = " + (phonemes[phonemes.Count() - 1].xmax).ToString().Replace(',', '.') + "\r";
            newHeader       += "\tintervals: size = "+nasalPhonemes.Count()+"\r";

            string newWordHeader = "\titem [2]:\r";
            newWordHeader       += "\t\tclass = \"IntervalTier\"\r";
            newWordHeader       += "\t\tname = \"word\"\r";
            newWordHeader       += "\t\txmin = 0\r";
            newWordHeader       += "\t\txmax = " + (phonemes[phonemes.Count() - 1].xmax).ToString().Replace(',', '.') + "\r";
            newWordHeader       += "\tintervals: size = " + nasalPhonemes.Count() + "\r";

            res = newHeader;
            res += printPraatIntervalsFromLists(nasalPhonemes.Count(), nasalPhonemes);
            res += newWordHeader;
            res += printPraatIntervalsFromLists(nasalWords.Count(), nasalWords);

            //Console.WriteLine(res);
            
            return res;

        }

        private void btn_abrir_textgrid_nasal_palabras_Click(object sender, EventArgs e) {

            openFileTextGrid.Filter = "TextGrids (*.TextGrid)|*.TextGrid|Todos los archivos (*.*)|*.*";
            DialogResult result = openFileTextGrid.ShowDialog();

            if (result == DialogResult.OK) {
                txt_input_textGrid_nasal_palabra.Text = openFileTextGrid.FileName;
            }

        }

        private void btn_procesar_nasal_palabras_Click(object sender, EventArgs e) {
            if (txt_input_textGrid_nasal_palabra.Text.Equals("") == true || txt_input_nasal_palabra.Text.Equals("") == true) {
                MessageBox.Show("Por favor seleccione un TextGrid");
            }
            else {

                //string output = "salida";
                //Console.WriteLine(txt_input_textGrid_nasal_palabra.Text);
                //Console.WriteLine(txt_input_nasal_palabra.Text);
                string output = enlazarSonidosPalabrasNasales(txt_input_textGrid_nasal_palabra.Text, txt_input_nasal_palabra.Text);

                txt_output_nasal_palabra.Text = output;

            }
        }

        private void btn_copiar_nasal_palabras_Click(object sender, EventArgs e) {
            System.Windows.Forms.Clipboard.SetText(txt_output_nasal_palabra.Text);
        }

        private void btn_limpiar_nasal_palabras_Click(object sender, EventArgs e)
        {
            txt_output_nasal_palabra.Text = "";
            txt_input_nasal_palabra.Text = "";
        }
    }
}

