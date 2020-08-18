using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeZipper
{
    class DeZipperMain
    {
#if BUILD_CUI
        #region CLI
        static void Main(string[] args)
        {
            int argc = args.Length;
            DeZipperCUI dezipper = null;

            if (argc == 0)  // DeZipper.exe만 입력한 경우.
            {
                Console.WriteLine("usage : DeZipper.exe [source_zip] [target_dir]");
                Console.WriteLine("(Help : DeZipper.exe -help)");
            }
            else if (argc == 1) // 리스트 출력 또는 -help
            {
                if (args[0].Equals("-h") || args[0].Equals("-help"))
                {
                    DeZipperCUI.PrintHelp();
                }
                else if (!args[0].Contains(".zip"))
                {
                    Console.WriteLine(args[1] + " is not a ZIP file.");
                }
                else
                {
                    dezipper = new DeZipperCUI(args[0], ".");
                    dezipper.PrintList();
                }
            }
            else if (argc == 2) // 기본 옵션으로 파일 삭제. 그 외의 경우는 없음. 없겠지뭐.
            {
                dezipper = new DeZipperCUI(args[0], args[1]);
                dezipper.Delete();
            }
            else if (argc >= 3) // 옵션을 사용해서 파일 삭제.
            {
                bool isExecutable = true;
                dezipper = new DeZipperCUI(args[0], args[1]);

                for (int i = 2; i < argc; i++)
                {
                    switch (args[i])
                    {
                        case "-s":
                        case "-silence":
                            dezipper.Silenced = true;
                            break;
                        case "-e":
                        case "-empty":
                            dezipper.Options |= DeleteOptions.DeleteEmptyDirectory;
                            break;
                        case "-z":
                        case "-zip":
                            dezipper.Options |= DeleteOptions.DeleteSourceZipFile;
                            break;
                        case "-r":
                        case "-recycle":
                            dezipper.Options |= DeleteOptions.ToRecycleBin;
                            break;
                        case "-ex":
                        case "-exclude":
                            i++;
                            while (i < argc)
                            {
                                isExecutable = dezipper.Delist(args[i]);
                                i++;
                            }
                            break;
                        default:
                            WhenUserDemandsWrongOptions();
                            isExecutable = false;
                            break;
                    }
                }

                if (isExecutable)
                    dezipper.Delete();
            }
            else
            {
                Console.WriteLine("이런 상황이 올 수도 있나요?");
            }
        }

        /// <summary>
        /// 알 필요 없다.
        /// </summary>
        static void WhenUserDemandsWrongOptions()
        {
            int rVal = new Random().Next(101);
            if (rVal <= 94)
                Console.WriteLine("Err: inaccurate command.");
            else if (rVal == 95)
                Console.WriteLine("Did you check your order?");
            else if (rVal == 96)
                Console.WriteLine("Well, I can't understand your claim.");
            else if (rVal == 97)
                Console.WriteLine("I'm afraid, I can't do that.");
            else if (rVal == 98)
                Console.WriteLine("Wh-what? What are you talking about?");
            else if (rVal == 99)
                Console.WriteLine("WRONG!!");
            else if (rVal == 100)
                Console.WriteLine("OH, SERIOUSLY?");

            Console.WriteLine("Help : DeZipper.exe -help");
        }
        #endregion
#elif BUILD_GUI
        #region GUI
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeZipperForm());
        }
        #endregion
#endif
    }
}
