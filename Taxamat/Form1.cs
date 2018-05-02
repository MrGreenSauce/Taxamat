using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace Taxamat
{
    
    public partial class Form1 : Form
    {
        const string ERROR1 = "Error: Unexpected file name.";
        const string ERROR2 = "Error: Unexpected file format.";
        const string ERROR3 = "Error: Input file has incorrect format or is opened elsewhere.";
        const string ERROR4 = "Error. One or more files have an incorrect format, or are opened elsewhere.";
        
       
        
        StreamWriter outputFile;
        StreamReader inputFile;
        StreamReader outputFileForFilter;
        string outputFilePath;

        string[] fileNamesForMerge = new string[18];
        string[] inputFilePaths = new string[12];
        List<int> abundancies = new List<int>();

       

        IEnumerable<string> namesRows;
        IEnumerable<string> nodesRows;
        IEnumerable<string> rows;
        
        bool namesOK = false;
        bool nodesOK = false;
        bool inputOK = false;
        bool mergedOK = false;

        bool downsample = false;
        bool createStatistics = false;

        string currentID;
        int rank;
       
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        
        

        private void loadNames_Click(object sender, EventArgs e)
        {
            namesOK = false;
            LoadNCBIDataFile("names.dmp", loadLbl);
        }

        private void loadNodes_Click_1(object sender, EventArgs e)
        {
            nodesOK = false;
            LoadNCBIDataFile("nodes.dmp", loadNodeLbl);
        }

        private void LoadNCBIDataFile(string fileName, Label label)
        {
                        
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog1.FileName;

                if (!FileNameIsCorrect(fullPath, fileName))
                {
                    SetLabel(label , ERROR1);
                    return;
                }

                SetLabel(label, "Reading '" + fileName + "' ...");
                label.Refresh();
                
                rows = File.ReadAllLines(fullPath);       
                string firstLine = rows.FirstOrDefault();  

                if (!FileFormatIsCorrect(fileName,firstLine)) {
                    SetLabel(label, ERROR2);
                    return;
                }
                

                SetLabel(label, UpdateLabelTextToFilePath(fullPath));

                CopyDataBase(fileName, rows);
                
                
            }
        }

        void SetLabel(Label label, string message) {
            label.Text = message;
        }        

        string UpdateLabelTextToFilePath(string labelText)
        {
            if (labelText.Length > 50)
            {
                return "..." + labelText.Substring(labelText.Length - 50);
            }
            else
            {
                return labelText;
            }
        }
               
        bool FileNameIsCorrect(string path, string name) {
            if (FindRightStr(path, name.Length) == name)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        void CopyDataBase(string fileName, IEnumerable<string> rows) {
            if (fileName == "names.dmp")
            {
                namesRows = rows;
                namesOK = true; 
                pbox_namesOk.Visible = true;
            }
            if (fileName == "nodes.dmp")
            {
                nodesRows = rows;
                nodesOK = true;
                pbox_nodesOk.Visible = true;
            }

        }

             
       
        //reads multiple file names into inputFilePaths
        private void readInputListBtn_Click_1(object sender, EventArgs e)
        {
            ClearInputFilePaths();

            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PopulateInputFilePaths(openFileDialog1.FileNames);
                                
                VerifyInputFileFormats();
            }
            else
            {
                MessageBox.Show("Unexpected error occured when opening the file dialog box.");
            }
                      
            openFileDialog1.Multiselect = false;
        }

        private void ClearInputFilePaths()
        {
            for (int i = 0; i < inputFilePaths.Length; i++)
            {
                inputFilePaths[i] = null;
            }
        }

        private void PopulateInputFilePaths(string[] fileNames)
        {
            int fileCount = 0;
            foreach (String fileName in fileNames)
            {
                if (fileCount > 10)
                {
                    break;
                }
                inputFilePaths[fileCount] = fileName;
                fileCount++;
            }
        }


        private void VerifyInputFileFormats()
        {
            if (inputFileFormatOk(inputFilePaths) == true)
            {
                inputOK = true;
            }
            else
            {
                inputOK = false;
            }
            UpdateInputUI(inputOK);
        }

        private void UpdateInputUI(bool inputOk) {
            if (inputOk)
            {
                pbox_inputOk.Visible = true;
                string labelText = WriteInputLabelText();
                inputLbl.Text = labelText;
            }
            else
            {
                pbox_inputOk.Visible = false;
                inputLbl.Text = ERROR3;
            }
        }

        private string WriteInputLabelText()
        {
            string labelText;
            if (inputFilePaths[0].Length > 50)
            {
                labelText = "..." + inputFilePaths[0].Substring(inputFilePaths[0].Length - 50);
            }
            else
            {
                labelText = inputFilePaths[0];
            }
            return labelText;
        }

        //creates hierarchy from loaded file
        private void createTaxListBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (inputOK && namesOK && nodesOK)
                {
                    int index = 0;

                    this.Enabled = false;
                    
                    while (inputFilePaths[index] != null)
                    {
                        // opens file dialog for result file
                        outputFilePath = RemoveTxtExtension(inputFilePaths[index]) + "_H";
                        inputFile = new System.IO.StreamReader(inputFilePaths[index]);

                        outputFile = new System.IO.StreamWriter(outputFilePath);
                        createTaxListBtn.Text = "Working on file " + (index + 1).ToString();
                        createTaxListBtn.Refresh();
                        pBar_hierarchy.Value = 0;
                        pBar_hierarchy.Refresh();

                        int lineCount = CountLinesInFile(inputFile);
                    
                        //reopens file for creating hierarchy
                        inputFile = new System.IO.StreamReader(inputFilePaths[index]);
                        string line;
                        int progress = 0;
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            string[] values = line.Split('\t');
                            string[] finalLine = new String[13];
                            for (int i = 0; i <= 12; i++)
                            {
                                finalLine[i] = "";
                            }

                            //searches actual source row in names and assigns ID(0) and Query Name(1) values
                            var foundName = namesRows.Where(delegate(string s) { return s.Contains(values[0]); });
                            foreach (var temp in foundName)
                            {
                                string[] tempNameValues = temp.Split('\t');
                                if (tempNameValues[2] == values[0])
                                {

                                    finalLine[0] = tempNameValues[0]; //ID
                                    finalLine[1] = values[0]; //Query name

                                    finalLine[12] = values[1];
                                }
                            }

                            //this fills fields when query is not found
                            if (finalLine[0] == "" && finalLine[1] == "")
                            {
                                finalLine[0] = "0";
                                finalLine[1] = values[0];
                                finalLine[2] = "not found";

                                for (int i = 4; i < 12; i++)
                                {
                                    finalLine[i] = "Unidentified";
                                }


                                finalLine[12] = values[1];

                            }

                            //searches for ID match and finds scientific name from names.dmp
                            foundName = namesRows.Where(delegate(string s) { return s.Contains(finalLine[0] + '\t' + "|"); });
                            foreach (var temp in foundName)
                            {
                                string[] tempNameValues = temp.Split('\t');
                                if (tempNameValues[6] == "scientific name" && tempNameValues[0] == finalLine[0])
                                {
                                    finalLine[2] = tempNameValues[2]; //scientific name
                                }
                            }

                            //uses ID found in previous foreach and looks up the current rank(3) in nodes.dmp
                            currentID = finalLine[0];
                            var foundNode = nodesRows.Where(delegate(string s) { return s.Contains(currentID); });
                            foreach (var temp in foundNode)
                            {
                                string[] tempNodeValues = temp.Split('\t');
                                if (tempNodeValues[0] == currentID)
                                {
                                    finalLine[3] = tempNodeValues[4]; //rank
                                }
                            }

                            
                            //fills in ranks
                            while (currentID != "1")
                            {
                                rank = ConvertRank(GetRank(currentID));
                                if (rank > 0)
                                {
                                    finalLine[GetRankPosition(rank)] = GetScientificName(currentID);

                                }

                                if (currentID == "Entry not found in nodes.dmp")
                                {
                                    break;
                                }
                                currentID = GetParentID(currentID);

                            }

                            
                            //if checkbox ticked this for loop fills empty fields with "n.a."
                            if (fillEmptyFields.Checked == true)
                            {
                                for (int i = 0; i < 12; i++)
                                {
                                    if (finalLine[i] == "")
                                    {
                                        if (i == 2)
                                        {
                                            finalLine[i] = "unknown";
                                        }
                                        else
                                        {
                                            finalLine[i] = "n.a.";
                                        }
                                    }
                                }
                            }

                            //assembles complete line and writes it into a file
                            outputFile.WriteLine(finalLine[0] + '\t' + finalLine[1] + '\t' + finalLine[2] + '\t' + finalLine[3] + '\t' + finalLine[4] + '\t' + finalLine[5] + '\t' + finalLine[6] + '\t' + finalLine[7] + '\t' + finalLine[8] + '\t' + finalLine[9] + '\t' + finalLine[10] + '\t' + finalLine[11] + '\t' + finalLine[12]);
                            progress++;
                            int progressPercent = Convert.ToInt32((Convert.ToDecimal(progress) / Convert.ToDecimal(lineCount) * 100));
                            pBar_hierarchy.Value = progressPercent;
                            progressLbl.Text = "Finished entries: " + progress.ToString();
                            progressLbl.Refresh();
                            pBar_hierarchy.Refresh();
                            this.Refresh();
                            this.WindowState = FormWindowState.Normal;

                           
                            Application.DoEvents();
                            this.Update();

                           

                            //resets final line
                            for (int i = 0; i <= 12; i++)
                            {
                                finalLine[i] = "";
                            }

                        }


                        outputFile.Close();
                        inputFile.Close();

                       
                        if (chbx_createFilteredList.Checked)
                        {
                            createTaxListBtn.Text = "Filtering...";
                        }



                        //Creates another file if chbx_createFilteredList is checked
                        /* filter logic
                                * 1. reads line in while loop
                                * 2. splits line for individual values
                                * 3. checks if value matches an active filter 
                                *  3a. if yes then nothing is done
                                *  3b. if no then the whole line is written into a new file. (new file will have the same path & name as the original output, with an F extension.
                                */
                        if (chbx_createFilteredList.Checked)
                        {
                            outputFileForFilter = new System.IO.StreamReader(outputFilePath);
                            StreamWriter filteredFile = new System.IO.StreamWriter(outputFilePath + "_f");

                            //removing selected taxa
                            while ((line = outputFileForFilter.ReadLine()) != null)
                            {

                                string[] values = line.Split('\t');
                                Boolean skipLine = false;

                                
                                if (chbx_removeMetazoa.Checked)
                                {
                                    if (values[10] == "Metazoa")
                                    {
                                        skipLine = true;
                                    }
                                }
                                
                                if (chbx_removeViridiplantae.Checked)
                                {
                                    if (values[10] == "Viridiplantae")
                                    {
                                        skipLine = true;
                                    }
                                }
                              
                                if (chbx_removeBacteria.Checked)
                                {
                                    if (values[11] == "Bacteria")
                                    {
                                        skipLine = true;
                                    }
                                }
                               
                                if (chbx_removeArchea.Checked)
                                {
                                    if (values[11] == "Archaea")
                                    {
                                        skipLine = true;
                                    }
                                }
                                if (chbx_removeFungi.Checked)
                                {
                                    if (values[10] == "Fungi")
                                    {
                                        skipLine = true;
                                    }
                                }
                                if (chbx_removeViruses.Checked)
                                {
                                    if (values[11] == "Viruses")
                                    {
                                        skipLine = true;
                                    }
                                }
                                if (chbx_removeUnidentified.Checked)
                                {
                                    if (values[2] == "not found")
                                    {
                                        skipLine = true;
                                    }
                                }
                                
                               


                                if (!skipLine)
                                {
                                    filteredFile.WriteLine(line);
                                }


                            }



                            outputFileForFilter.Close();
                            filteredFile.Close();
                            createTaxListBtn.Text = "Output file closed.";
                        }


                        if (chbx_createSeparateFileStatistics.Checked)
                        {
                            createTaxListBtn.Text = "Creating separate files...";
                        }

                        //creates separate files for each tax level
                        if (chbx_createSeparateFileStatistics.Checked == true)
                        {
                            for (int ind = 4; ind < 12; ind++)
                            {
                                CreateSeparateStatisticsFiles(outputFilePath, ind);
                                if (chbx_createFilteredList.Checked == true)
                                {
                                    CreateSeparateStatisticsFiles(outputFilePath + "_f", ind);
                                }
                            }

                        }
                        pBar_hierarchy.Value = 100;

                        index++;
                    }
                    
                    this.Enabled = true;
                    createTaxListBtn.Text = "Finished. Click again for another run with different settings!";
                    createTaxListBtn.Enabled = true;
                    progressLbl.Text = "Warning: Another run on the same files \n will overwrite previous result(s)!";
                }
                else
                {
                    MessageBox.Show("Please load names.dmp, nodes.dmp and your input file first!");
                }
            
            }
            catch
            {
                {
                    MessageBox.Show("Error! Please check that no input or output files are opened elsewhere!");
                    createTaxListBtn.Text = "Create Hierarchy";
                    
                    try
                    {
                        inputFile.Close();

                    }
                    catch
                    {
                        MessageBox.Show("An unexpected error occured when trying to close an already closed file");
                        //file is already closed
                    }
                    try
                    {
                        outputFile.Close();
                    }
                    catch
                    {
                        MessageBox.Show("An unexpected error occured when trying to close an already closed file");
                        //file is already closed
                    }
                    
                }
            }
           
        }


        int CountLinesInFile(StreamReader file) {
            //reads source file row by row
            string line;
            int lineCount = 0;
            //counts lines and closes file
            while ((line = inputFile.ReadLine()) != null)
            {
                lineCount++;
            }
           

            inputFile.Close();
            return lineCount;
        }

       
        //this calculates the shannon's and simpson's index;
        List<double> Statistics(List<int> abundancies)
        {
            List<double> createdStatistics = new List<double>();
            int len;
            int totalOrganisms;
            totalOrganisms = 0;
            len = abundancies.Count;

            //Calculate the sum of all entries
            foreach (int ab in abundancies)
            {
                totalOrganisms += ab;
            }

           
            if (totalOrganisms == 0)
            {
                return new List<double>();
            }


            //SHANNON
            createdStatistics.Add(ShannonIndex(abundancies, totalOrganisms));
            
            //SIMPSONS
            createdStatistics.Add(SimpsonIndex(abundancies, totalOrganisms));

            return createdStatistics;
        }

        double SimpsonIndex(List<int> abundancies, int totalOrganisms)
        {
            List<double> simpsonNiTimesNiMinusOne = new List<double>();
            foreach (int ab in abundancies)
            {
                double res;
                res = (ab * (ab - 1));
                simpsonNiTimesNiMinusOne.Add(res);
            }

            double sumSimpsonNi;
            sumSimpsonNi = 0D;
            foreach (double ni in simpsonNiTimesNiMinusOne)
            {
                sumSimpsonNi += ni;
            }
            double simpson;
            simpson = 0D;
            simpson = sumSimpsonNi / (totalOrganisms * (totalOrganisms - 1));

            return simpson;
        }

        double ShannonIndex(List<int> abundancies, int totalOrganisms)
        {
            List<double> aiValues = new List<double>();
            // transform values to ai/totalOrganisms which is pi
            foreach (int ab in abundancies)
            {
                double res;
                res = (double)ab / totalOrganisms;
                aiValues.Add(res);
            }

            List<double> piPowPi = new List<double>();
            //calculates pi*pi values
            foreach (double pi in aiValues)
            {
                double piPow;
                piPow = Math.Pow(pi, pi);
                piPowPi.Add(piPow);
            }

            double shannons;
            shannons = 1D;
            foreach (double piSq in piPowPi)
            {
                shannons = shannons * piSq;
            }
            shannons = (double)1 / shannons;
           
            shannons = Math.Log(shannons, 2D);
            return shannons;
        }

        //1. read source file into a list
        //2. loop through list
        //  -look for entry in another list
        //  -if there is entry then add value
        //  -else add new entry
        void CreateSeparateStatisticsFiles(string SourcePath, int position)
        {
            string[] values;
            string currentName;
            int currentAbundancy;
            StreamReader source = new StreamReader(SourcePath);
            List<string> sourceList = new List<string>();
           
            string line;
            while ((line = source.ReadLine()) != null) {
                sourceList.Add(line);
            }
            List<string> resultList = new List<string>();

            while (sourceList.Count > 0)
            {
                List<string> tempList = new List<string>();
                currentAbundancy = 0;
                values = sourceList[0].Split('\t');
                currentName = values[position];
                foreach (string sourceLine in sourceList)
                {
                    values = sourceLine.Split('\t');
                    if (values[position] == currentName)
                    {
                       currentAbundancy += Int32.Parse(values[12]);
                        
                    }
                    else
                    {
                        tempList.Add(sourceLine);
                    }
                }
                sourceList = tempList;
                resultList.Add(currentName + '\t' + currentAbundancy.ToString());
            }

            string fileTag;
            fileTag = BuildFileTag(position);

            StreamWriter resultFile = new StreamWriter(SourcePath + fileTag);

            foreach (string finalLine in resultList)
            {
                resultFile.WriteLine(finalLine);
            }
            resultFile.Close();
            source.Close();
           
       

        }

        private string BuildFileTag(int pos)
        {
            switch (pos)
            {
                case 4:
                    return "_Species";
                case 5:
                    return "_Genus";
                case 6:
                    return "_Family";
                case 7:
                    return "_Order";
                case 8:
                    return "_Class";
                case 9:
                    return "_Phylum";
                case 10:
                    return "_Kingdom";
                case 11:
                    return "_Superkingdom";
                default:
                    return "ERROR-taxon index out of range-";
            }
        }

    

        // FindRightStr takes a string and an integer and returns a substring which contains the right side of the string 
        //with the exact number of characters defined by the second parameter
        private string FindRightStr(string filepath, int charNum) {
            if (filepath != null) {
                int l = filepath.Length;
                string substring;
                substring = filepath.Substring(l - charNum, charNum);
                return substring;
            }
            else {
                return null;
            }
        }

        //Takes id and returns the ID of the parent
        private string GetParentID(string ID)
        {
            
            var foundNode = nodesRows.Where(delegate(string s) { return s.Contains(ID +'\t' + "|"); });
            foreach (var temp in foundNode)
            {
                string[] tempNodeValues = temp.Split('\t');
                if (tempNodeValues[0] == ID)
                {
                    return tempNodeValues[2];
                }
                
            }
            return "Entry not found in nodes.dmp";
        }


        //Takes ID as string and returns the rank 
        private string GetRank(string ID)
        {
            var foundNode = nodesRows.Where(delegate(string s) { return s.Contains(ID + '\t' + "|"); });
            foreach (var temp in foundNode)
            {
                string[] tempNodeValues = temp.Split('\t');
                if (tempNodeValues[0] == ID)
                {
                    return tempNodeValues[4];
                }
               
            }
            return "Entry not found in nodes.dmp";
        }

        //takes ID and retruns the scientific name
        private string GetScientificName(string ID)
        {
            var foundName = namesRows.Where(delegate(string s) { return s.Contains(ID + '\t' + "|"); });
            foreach (var temp in foundName)
            {
                string[] tempNameValues = temp.Split('\t');
                if (ID == tempNameValues[0] && tempNameValues[6] == "scientific name")
                {
                    return tempNameValues[2];
                }   
            }
            return "Entry not found in names.dmp";
        }

        //Takes rank and converts it into an integer representing that rank
        private int ConvertRank(string rnk)
        {
            switch (rnk)
            {
                case "species":
                    return 1;
                case "genus":
                    return 2;
                case "family":
                    return 3;
                case "order":
                    return 4;
                case "class":
                    return 5;
                case "phylum":
                    return 6;
                case "kingdom":
                    return 7;
                case "superkingdom":
                    return 8;
                default:
                    return -1;
            }
        }

        //Takes rank as integer and returns the position of the rank in the array (4-11)
        private int GetRankPosition(int rnk)
        {
            int rankPosition;
            rankPosition = rnk + 3;
            return rankPosition;
            /* obsolete, can be deleted if everything works
            switch (rnk)
            {
                case 1:
                    return 4;
                case 2:
                    return 5;
                case 3:
                    return 6;
                case 4:
                    return 7;
                case 5:
                    return 8;
                case 6:
                    return 9;
                case 7:
                    return 10;
                case 8:
                    return 11;
                default:
                    return -1;

            }
             */
        }

        //Checks input file format for hierarchy creation & file merger. Takes a string array of inputfile paths and checks each of them. They should have exactly 2 columns in each row.
        //All cells must be filled.
        private bool inputFileFormatOk(string[] path)
        {
            int index = 0;
            bool formatOk = true;
            if (path[0] != null)
            {
                while (index < path.Length && path[index] != null)
                {
                    try
                    {
                        inputFile = new System.IO.StreamReader(path[index]);
                    }
                    catch
                    {

                        return false;
                    }
                    string line;
                    if ((line = inputFile.ReadLine()) == null)
                    {
                        formatOk = false;
                    }
                    inputFile.Close();
                    
                    
                    inputFile = new System.IO.StreamReader(path[index]);
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        try
                        {
                            string[] values = line.Split('\t');
                            if (values.Length == 2 && values[0] != null && values[1] != null && values[0] != "" && values[1] != "")
                            {
                                try
                                {
                                    int temp = Int32.Parse(values[1]);
                                }
                                catch
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                formatOk = false;
                            }
                        }
                        catch
                        {
                            return false;
                        }
                        
                    }
                    
                    index++;
                }
                inputFile.Close();
                if (formatOk == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                inputFile.Close();
                return false;
            }
            
                
        }

        /*
        private void fileForStatisticsFormatIsOk(string file)
        {

        }
        */

        //Checks loaded *.dmp files for correct format
        //takes filetype which should be "names.dmp" or "nodes.dmp" 
        //returns true if names.dmp or nodes.dmp has the correct format otherwise returns false
       
        
        bool FileFormatIsCorrect(string filetype, string firstRow)
        {
            string[] tempComponents;
            
            if (filetype == "names.dmp")
            {
                try {
                    tempComponents = firstRow.Split('\t');
                }
                catch
                {
                    return false;
                }
                
                if (tempComponents.Length == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (filetype == "nodes.dmp")
            {
                try
                {
                    tempComponents = firstRow.Split('\t');
                }
                catch
                {
                    return false;
                }




                if (tempComponents.Length == 26)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



            return false;
        }

        //empty field checkbox feedback
        private void fillEmptyFields_CheckedChanged(object sender, EventArgs e)
        {

        }

       
        private void chbx_createFilteredList_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbx_removeMetazoa.Enabled)
            {
                chbx_removeMetazoa.Enabled = false;
                chbx_removeViridiplantae.Enabled = false;
                chbx_removeFungi.Enabled = false;
                chbx_removeViruses.Enabled = false;
                chbx_removeBacteria.Enabled = false;
                chbx_removeArchea.Enabled = false;
                chbx_removeUnidentified.Enabled = false;

                chbx_removeMetazoa.Checked = false;
                chbx_removeViridiplantae.Checked = false;
                chbx_removeFungi.Checked = false;
                chbx_removeViruses.Checked = false;
                chbx_removeBacteria.Checked = false;
                chbx_removeArchea.Checked = false;
                chbx_removeUnidentified.Checked = false;
            }
            else
            {
                chbx_removeMetazoa.Enabled = true;
                chbx_removeViridiplantae.Enabled = true;
                chbx_removeFungi.Enabled = true;
                chbx_removeViruses.Enabled = true;
                chbx_removeBacteria.Enabled = true;
                chbx_removeArchea.Enabled = true;
                chbx_removeUnidentified.Enabled = true;
            }
        }

        private void chbx_createSeparateFileStatistics_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_addFilesForMerge_Click(object sender, EventArgs e)
        {
            lbx_Files.Items.Clear();
            for (int i = 0; i < fileNamesForMerge.Length; i++)
            {
                fileNamesForMerge[i] = null;
            }
            int fileCount = 0;
            openFileDialog1.Multiselect = true;

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //The next condition checks the file format of all merged files
                if (inputFileFormatOk(openFileDialog1.FileNames))
                {
                    foreach (string file in openFileDialog1.FileNames)
                    {

                        if (fileCount > 16)
                        {

                            lbx_Files.Items.Clear();
                            lbx_Files.Items.Add("Currently only a maximum of 16 files are allowed to be merged at a time");
                            break;

                        }

                        string textItem;
                        if (file.Length > 60)
                        {
                            textItem = "..." + file.Substring(file.Length - 60);
                        }
                        else
                        {
                            textItem = file;
                        }
                        fileNamesForMerge[fileCount] = file;
                        lbx_Files.Items.Add(textItem);
                        fileCount += 1;
                    }
                }
                else {
                    lbx_Files.Items.Clear();
                    lbx_Files.Items.Add(ERROR4);
                }
                
            }
            openFileDialog1.Multiselect = false;
        }


        //Takes a filepath and checks if it ends in .txt
        //if yes, it removes the ending
        private string RemoveTxtExtension(string filepath)
        {
            if (FindRightStr(filepath, 4) == ".txt")
            {
                filepath = filepath.Remove(filepath.Length - 4, 4);
                return filepath;
            }
            else
            {
                return filepath;
            }
        }

        private void btn_Merge_Click(object sender, EventArgs e)
        {
            //A header based on filenames is created for each column, and is written into the merged file's first row
            //just before writing the actual data  
            string header;
            header = "Name";
            int fileNamesIndex = 0;
            while (fileNamesForMerge[fileNamesIndex] != null)
            {
                if (fileNamesForMerge[fileNamesIndex].Contains('\\'))
                {
                    header += '\t' + fileNamesForMerge[fileNamesIndex].Split('\\').Last();

                }
                else
                {
                    header += '\t' + fileNamesForMerge[fileNamesIndex];
                }
                fileNamesIndex++;
            }
            
            
           

            if (fileNamesForMerge[0] != null) 
            {
                List<string> mergedString = new List<string>();
                
                StreamReader mainFile = new System.IO.StreamReader(fileNamesForMerge[0]);
                
              
                string mergedPath = "0";
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    mergedPath = saveFileDialog1.FileName;
                }

                if (mergedPath == null || mergedPath == "0")               
                {
                    return;
                }

                StreamWriter mergedFile = new System.IO.StreamWriter(mergedPath + "_merged");
                
                string line;
                while ((line = mainFile.ReadLine()) != null)
                {
                    mergedString.Add(line);    
                }
                mainFile.Close();
                int index = 1;
                while (fileNamesForMerge[index] != null)
                {
                    StreamReader newFile = new System.IO.StreamReader(fileNamesForMerge[index]);
                    List<string> stringToMerge = new List<string>();
                    string newLine;
                    //1. read new file into a list - done
                    while ((newLine = newFile.ReadLine()) != null)
                    {
                        stringToMerge.Add(newLine);
                    }
                    //2. loop thorugh the old list and if entry exists in new list then add abundancy & delete entry from new list
                    bool added = false;
                    for (int i = 0; i < mergedString.Count; i++)
                    {
                        string[] valuesOld = mergedString[i].Split('\t');
                        for (int k = 0; k < stringToMerge.Count; k++)
                        {
                            string[] valuesNew = stringToMerge[k].Split('\t');
                            if (valuesOld[0] == valuesNew[0])
                            {
                                //adds abundancy to merged list
                                mergedString[i] = mergedString[i] + '\t' + valuesNew[1];
                                
                                stringToMerge[k] = null;
                                added = true;
                            }
                            
                            
                        }
                        //removes all null items from new list (these have been added already)
                        stringToMerge.RemoveAll(item => item == null);
                        //3. if entry does not exist then add 0 to old list
                        if (!added)
                        {
                            mergedString[i] = mergedString[i] + '\t' + "0";
                        }
                        added = false;
                       
                    }
                    //4. add all remaining entries from new list with a zero in previous positions
                    foreach (string s in stringToMerge)
                    {
                        string[] values = s.Split('\t');
                        string newEntry;
                        newEntry = values[0];
                        for (int i = 1; i <= index; i++)
                        {
                            newEntry += '\t' + "0";
                        }
                        newEntry += '\t' + values[1];
                        mergedString.Add(newEntry);
                    }
                    newFile.Close();   
                    index++;
                }
                mergedFile.WriteLine(header);
                foreach (string l in mergedString)
                {
                    mergedFile.WriteLine(l);
                }
                mergedFile.Close();
                lbx_Files.Items.Clear();

               
                lbx_Files.Items.Add("The selected files have been merged to: ");

                string itemString;
                if (mergedPath.Length > 50)
                {
                    itemString = "..." + mergedPath.Substring(mergedPath.Length - 50);
                }
                else
                {
                    itemString = mergedPath;
                }
                lbx_Files.Items.Add(itemString + "_merged");
            }
            
        }

        //Checks the file format of the merged file
        private bool MergedFileFormatOk(string filePath) {
            try
            {
                StreamReader newFile = new System.IO.StreamReader(filePath);
                List<string> mergedRows = new List<string>();
                string newLine;
                while ((newLine = newFile.ReadLine()) != null)
                {
                    mergedRows.Add(newLine);
                }
                newFile.Close();

                //if our file is empty then we should return false
                if (mergedRows.Count == 0)
                {
                    return false;
                }
                //get the number of rows and columns;
                int columnCount = mergedRows[0].Split('\t').Length;
                int rowCount = mergedRows.Count;

                //if we don't have at least 2 columns then the file format is not ok
                if (columnCount < 2)
                {
                    return false;
                }

                //if we don't have al least 2 rows then return false
                if (rowCount < 2)
                {
                    return false;
                }

                //the first row should contain columnCount number of strings, and only the first should be allowed to be empty
                string[] testString = mergedRows[0].Split('\t');
                if (testString.Length != columnCount)
                {
                    return false;
                }
                for (int i = 0; i < columnCount; i++)
                {
                    if (testString[i] == "" && i != 0)
                    {
                        return false;
                    }
                }

                //check all rows, they all should have columnCount number of columns
                foreach (string s in mergedRows)
                {
                    if (s.Split('\t').Length != columnCount)
                    {
                        return false;
                    }
                }

                //we check all columns, it should have non-empty strings in all rows, except the first
                for (int i = 0; i < mergedRows.Count; i++)
                {
                    testString = mergedRows[i].Split('\t');
                    for (int k = 0; k < testString.Length; k++)
                    {
                        if (testString[k] == "" && i != 0)
                        {
                            return false;
                        }
                    }
                }

                //here we check all rows and columns, except the firsts
                //each cell must contain an integer
                for (int i = 1; i < mergedRows.Count; i++)
                {
                    testString = mergedRows[i].Split('\t');
                    for (int k = 1; k < testString.Length; k++)
                    {
                        try
                        {
                            int test = Int32.Parse(testString[k]);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }


                //if we get this far, it means that the file format is ok
                return true;
            }
            catch
            {
                MessageBox.Show("File could not be opened. Make sure it is not opened in other programs!");
                return false;
            }
            
        }

        private void btn_LoadMergedFile_Click(object sender, EventArgs e)
        {
            pbox_statisticsOk.Visible = false;
            
            if (createStatistics == false && downsample == false) {
                lbl_statisticsCreatedFromMerged.Text = "Please check at least one of the checkboxes!";
                return;
            }
            openFileDialog1.Multiselect = false;
            string fullPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fullPath = openFileDialog1.FileName;
                lbl_statisticsCreatedFromMerged.Text = "Working...";
                lbl_statisticsCreatedFromMerged.Refresh();
                //Check file format. 
                //Merged files should have n rows, and m colomns.
                //Each row is tab delimited, starts with a string and contains m-1 integers.
                //Neither n or m can be 0
                //The first row contains a header, string each, may not be empty except the very first;
                
                if (MergedFileFormatOk(fullPath) == true)
                {
                    mergedOK = true;
                    string labelText;
                    labelText = "Results created from:";
                    if (fullPath.Length > 40)
                    {
                        labelText += " ..." + fullPath.Substring(fullPath.Length - 40);
                    }
                    else
                    {
                        labelText += fullPath;
                    }
                    lbl_statisticsCreatedFromMerged.Text = labelText;
                }
                else
                {
                    mergedOK = false;
                    lbl_statisticsCreatedFromMerged.Text = ERROR3;
                    lbl_statisticsCreatedFromMerged.Text = "";
                    pbox_statisticsOk.Visible = false;
                }


                //if the fileformat is ok, then load the file into a list
                if (mergedOK) {
                    StreamReader newFile = new System.IO.StreamReader(fullPath);
                    List<string> mergedRows = new List<string>();
                    string newLine;
                    while ((newLine = newFile.ReadLine()) != null)
                    {
                        mergedRows.Add(newLine);
                    }
                    newFile.Close();
                    //we have the list of rows at this point, and the format is correct as well.
                    //here we get the number of rows and number of columns as well
                    int columnCount = mergedRows[0].Split('\t').Length;
                    int rowCount = mergedRows.Count;
                
                    //put all the columns in a two dimensional array
                    //we ignore the first row since it contains the headers!!!
                    //similarly the first column contains the names of taxa!!!

                    //create an array of integers to hold the sum of each column
                    int[] totalCounts = new int[columnCount];
                    for (int i = 0; i < totalCounts.Length; i++)
                    {
                        totalCounts[i] = 0;
                    }


                    int[,] mergedCells = new int[columnCount, rowCount];
                    for (int row = 1; row < rowCount; row++)
                    {
                        string[] thisRow = mergedRows[row].Split('\t');
                        for (int col = 1; col < columnCount; col++)
                        {
                            mergedCells[col, row] = Int32.Parse(thisRow[col]);
                            totalCounts[col] += mergedCells[col, row];
                        }
                    }

                    //header
                    string header;
                    header = mergedRows[0];

                    
                    //strings from the first column
                    string[] taxa = new string[rowCount];
                    for (int row = 0; row < rowCount; row++) {
                        string[] thisRow = mergedRows[row].Split('\t');
                        taxa[row] = thisRow[0] + '\t';
                    }
                    
                    //Downsampling
                    //We find the column with the lowest count and store the value in lowestCount
                    int lowestCount = -1;
                    for (int col = 1; col < columnCount; col++)
                    {
                        if (lowestCount == -1)
                        {
                            lowestCount = totalCounts[col];
                        }
                        else {
                            if (lowestCount > totalCounts[col]) {
                                lowestCount = totalCounts[col];
                            }
                        }
                    }

                    if (downsample && rbtn_userDefined.Checked) {
                        
                        int targetValue = Convert.ToInt32(nUD_downsampleTarget.Value);
                        lowestCount = targetValue;
                    }

                    //We write downsampling results here
                    if (downsample)
                    {

                        //downsampling
                        int[,] downsampledData = DownsampledArray(mergedCells, lowestCount);
                        mergedCells = downsampledData;
                        
                        //writing data
                        List<string> downSampledRows = new List<string>();
                        downSampledRows.Add(header);
                        for (int row = 1; row < rowCount; row++) {
                            string downSampledLine = taxa[row];
                            for (int col = 1; col < columnCount; col++) {
                                downSampledLine += downsampledData[col, row].ToString() + '\t';
                            }
                            downSampledRows.Add(downSampledLine);
                        }
                        
                        //here we remove those lines that have only 0 in them
                        List<string> tempList = new List<string>();
                        bool firstRow = true;
                        foreach (string s in downSampledRows) {
                            string[] downsampledValues = s.Split('\t');
                            int rowTotal = 0;
                            for (int l = 1; l < downsampledValues.Length; l++)
                            {
                                try {
                                    rowTotal += Convert.ToInt32(downsampledValues[l]);
                                }
                                catch {
                                    if (firstRow)
                                    {
                                        tempList.Add(s);
                                        firstRow = false;
                                    }
                                }
                                
                            }
                            if (rowTotal > 0)
                            {
                                tempList.Add(s);
                            }
                        }
                        downSampledRows = tempList;
                        fullPath += "_downsampled";
                        try
                        {
                            StreamWriter downsampledFile = new StreamWriter(fullPath);
                            foreach (string s in downSampledRows)
                            {
                                downsampledFile.WriteLine(s.TrimEnd('\t'));
                            }

                            downsampledFile.Close();
                            pbox_statisticsOk.Visible = true;
                        }
                        catch
                        {
                            MessageBox.Show("Writing error. Make sure that a file with the same name is not opened elsewhere!");
                            lbl_statisticsCreatedFromMerged.Text = "Error. File might be opened elsewhere.";
                            pbox_statisticsOk.Visible = false;
                        }
                        
                        

                       
                    }


                   
                 

                    //creating statistics
                    if (createStatistics)
                    {
                        List<double>[] statisticsResults = new List<double>[columnCount];


                        List<int> sampleAbundancies = new List<int>();
                        for (int col = 1; col < columnCount; col++)
                        {
                            for (int row = 1; row < rowCount; row++)
                            {
                                sampleAbundancies.Add(mergedCells[col, row]);
                            }


                            //list of statistics for each column is created here
                            statisticsResults[col] = new List<double>(Statistics(sampleAbundancies));
                            sampleAbundancies.Clear();
                        }
                        //construct list of strings to write into a file
                        List<string> statisticsLinesToFile = new List<string>();

                        string line = "";
                        //create header line
                        line = mergedRows[0];
                        statisticsLinesToFile.Add(line);

                        //create rest of lines
                        line = "";
                        for (int row = 0; row < statisticsResults[1].Count; row++)
                        {
                            switch (row)
                            {
                                case 0:
                                    line = "Shannon";
                                    break;
                                case 1:
                                    line = "Simpson";
                                    break;
                                default:
                                    break;
                            }

                            //builds the lines for writing into a file
                            for (int c = 1; c < columnCount; c++)
                            {
                                line += '\t' + statisticsResults[c][row].ToString().Substring(0,7);
                            }


                            statisticsLinesToFile.Add(line);

                        }


                        //write created statistics into a file into a file
                        try
                        {
                            StreamWriter statisticsFile = new StreamWriter(fullPath + "_statistics");
                            foreach (string s in statisticsLinesToFile)
                            {
                                statisticsFile.WriteLine(s);
                            }
                            statisticsFile.Close();
                            pbox_statisticsOk.Visible = true;
                        }
                        catch
                        {
                            MessageBox.Show("Writing error. Make sure that a file with the same name is not opened elsewhere!");
                            lbl_statisticsCreatedFromMerged.Text = "Error. File might be opened elsewhere.";
                            pbox_statisticsOk.Visible = false;
                        }
                        
                        
                    }
                    
                    pbar_statistics.Value = 0;
                                       
                }
                


            }
        }

        int[,] DownsampledArray(int[,] original, int targetValue)
        {
            //variables for the progress bar
            int totalReadsToRemove = 0;
            int readsRemoved = 0;
            


            int[,] result = original;
            Random rnd = new Random();
            for (int col = 1; col < original.GetLength(0); col++)
            {
                totalReadsToRemove += Sum(result, col) - targetValue;
            }

            for (int col = 1; col < original.GetLength(0); col++)
            {
                
                while (Sum(result, col) > targetValue)
                {
                    int limit = rnd.Next(1, Sum(result, col));
                    int currentTotal = 0;
                    int currentRow = 1;
                    while (true)
                    {
                        currentTotal += result[col, currentRow];
                        if (currentTotal >= limit)
                        {
                            result[col, currentRow] -= 1;

                            readsRemoved++;
                            pbar_statistics.Value = Convert.ToInt32((Convert.ToDecimal(readsRemoved) / Convert.ToDecimal(totalReadsToRemove) * 100));
                            break;
                        }
                        currentRow++;
                    }
                    pbar_statistics.Refresh();
                    Application.DoEvents();

                }

            }
            
            return result;
        }

        int Sum(int[,] dataArray, int column) {
            int result = 0;
            
            for (int row = 1; row < dataArray.GetLength(1); row++)
            {   
                result += dataArray[column, row];
            }
            return result;
        }

        List<int> DownsampledList(List<int> originalList, int targetValue) {
            List<int> abundancies = new List<int>(originalList);
            int totalCount = 0;
            foreach (int count in abundancies) {
                totalCount += count;
            }
            Random rand = new Random();
            while (totalCount > targetValue) {
                int random = rand.Next(targetValue + 1);
                int cumulative = 0;
                for (int i = 0; i < abundancies.Count; i++)
                {
                    cumulative += abundancies[i];
                    if (cumulative >= random) {
                        abundancies[i] = abundancies[i] - 1;
                        totalCount -= 1;
                    }
                }
            }

            return abundancies;
        }

        private void chbx_CreateStatistics_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_CreateStatistics.Checked)
            {
                createStatistics = true;
                lbl_statisticsCreatedFromMerged.Text = "";
            }
            else {
                createStatistics = false;
            }
        }

        private void chbx_downsample_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_downsample.Checked)
            {
                downsample = true;
                lbl_statisticsCreatedFromMerged.Text = "";
                gbox_downsamplingMethod.Enabled = true;
            }
            else
            {
                downsample = false;
                gbox_downsamplingMethod.Enabled = false;
            }
        }

        private void fillEmptyFields_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!fillEmptyFields.Checked)
            {
                fillEmptyFields.Text = "Fill empty fields. WARNING: File mering files requieres all fields to be filled! It is recommended to leave this checked!";
            }
            else {
                fillEmptyFields.Text = "Fill empty fields.";
            }
        }

        private void rbtn_userDefined_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_userDefined.Checked)
            {
                nUD_downsampleTarget.Enabled = true;
            }
            else {
                nUD_downsampleTarget.Enabled = false;
            }
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {

        }

        private void loadLbl_Click(object sender, EventArgs e)
        {

        }

       
       
       
    }
}
