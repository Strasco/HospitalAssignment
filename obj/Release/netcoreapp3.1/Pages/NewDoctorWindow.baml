   M S B A M L   `   `   `  ���� N  JEssensysHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EssensysHospitalWPFEssensysHospitalWPF  )    #EssensysHospitalWPF.NewDoctorWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:EssensysHospitalWPF       � WindowStartupLocation$  Manual=� � Title$ 	NewDoctor��$��500         ��$	��800��.��� ���	#FF13BCD6$��0,0,0,-6q�.+��� $��
Doctor Nou��$
��Left=�$��	10,10,0,0q�$	��Top=�$��48(�$
��Bold"�$��Italic$��� $��Nume:��$
��Left=�$��	53,76,0,0q�$	��Top=�$��20(��� $��Prenume:��$
��Left=�$��
53,113,0,0q�$	��Top=�$��20(��� $��Nume:��$
��Left=�$��	53,76,0,0q�$	��Top=�$��20(��� $	��CNP��$
��Left=�$��
53,150,0,0q�$	��Top=�$��20(��� $��Data Angajare:��$
��Left=�$��
53,187,0,0q�$	��Top=�$��20(��� $��Universitate absolvita:��$
��Left=�$��
53,224,0,0q�$	��Top=�$��20(��� $��Durata rezidentiat:��$
��Left=�$��
53,261,0,0q�$	��Top=�$��20(��� $��Nota rezidentiat:��$
��Left=�$��
53,298,0,0q�$	��Top=�$��20(��� -   $��Inapoi��$
��Left=�$��725,424,0,0q�$	��Top=�$��33��$��55���� -    ��Name$ nameDoctorText��$
��Left=�$��30��$��
276,80,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��146��$��29��$��20(�$
��nume���� -   $ forNameDoctorText��$
��Left=� �� 	MaxLength$ 30��$��275,117,0,0q�$��prenume��$
 Wrap=�$	��Top=�$	��147��$��29��$��20(��� -   $ cnpDoctorText��$
��Left=�$ 13��$��276,154,0,0q�$
 Wrap=�$	��Top=�$	��157��$��29��$��20(��� -   $ UniversityTextBox��$
��Left=�$��276,228,0,0q�$��universitate��$
 Wrap=�$	��Top=�$	��123��$��29��$��20(�(  "System.Windows.Controls.DatePicker  -     Name$ 
datePicker��$
��Left=�$��276,193,0,0q�$	��Top=�$	��123��$��30��$��20(��� -   $ residencyDurationTextBox��$
��Left=�$ 1��$��276,265,0,0q�$��0��$
 Wrap=�$	��Top=�$	��146��$��29��$��20(��� -   $ residencyGradeTextBox��$
��Left=�$ 2��$��276,302,0,0q�$��0��$
 Wrap=�$	��Top=�$	��146��$��29��$��20(��� -	   $��Adaugare��$
��Left=�$��
54,423,0,0q�$	��Top=�$��34��$��70���� -
    ��Name$ errorRichText��$��486,94,84,230q�${�False��
���  ��. �/� �� $��Specializare��$
��Left=�$��
83,359,0,0q�$	��Top=�$��20(�	� -    	�Name$ 	cardioBtn��$��Cardiologist��$
��Left=�$��276,340,0,0q�$	��Top=� 	� 	GroupName$
 spec��$��22��$	��111��$��14(�	� -   $ internalBtn��$��Medicina Interna��$
��Left=�$��276,367,0,0q�$	��Top=�$
 spec��$��22��$	��134��$��14(�	� -   $ orthoBtn��$��	Ortopedic��$
��Left=�$��276,395,0,0q�$	��Top=�$
 spec��$��22��$	��111��$��14(�