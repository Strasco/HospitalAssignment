   M S B A M L   `   `   `  ����N  JEssensysHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EssensysHospitalWPFEssensysHospitalWPF  5   	   )    #EssensysHospitalWPF.NewDoctorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:EssensysHospitalWPF     5   	     � WindowStartupLocation$  Manual=�5   	    � Title$ 	NewDoctor��5	   	   $��500         ��6   $	��800��5
      .��5      � ���	#FF13BCD6$��0,0,0,-6q�6"   .+�5   
   �� $��
Doctor Nou��6   $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $��48(�6k   $
��Bold"�6y   $��Italic$�6�   �� 5   
   $��Nume:��6   $
��Left=�6    $��	53,76,0,0q�6;   $	��Top=�6N   $��20(�6f   �� 5   
   $��Prenume:��6   $
��Left=�6#   $��
53,113,0,0q�6>   $	��Top=�6R   $��20(�6j   �� 5   
   $��Nume:��6   $
��Left=�6    $��	53,76,0,0q�6;   $	��Top=�6N   $��20(�6f   �� 5   
   $	��CNP��6   $
��Left=�6   $��
53,150,0,0q�69   $	��Top=�6M   $��20(�6e   �� 5   
   $��Data Angajare:��6   $
��Left=�6)   $��
53,187,0,0q�6D   $	��Top=�6X   $��20(�6p   �� 5   
   $��Universitate absolvita:��6   $
��Left=�62   $��
53,224,0,0q�6M   $	��Top=�6a   $��20(�6y   �� 5   
   $��Durata rezidentiat:��6   $
��Left=�6.   $��
53,261,0,0q�6I   $	��Top=�6]   $��20(�6u   �� 5   
   $��Nota rezidentiat:��6   $
��Left=�6,   $��
53,298,0,0q�6G   $	��Top=�6[   $��20(�6s   �� 5   
   -   5        $��Inapoi��5      $
��Left=�6"   $��725,424,0,0q�6=   $	��Top=�6R   $��33��6j   $��55��6v   6�   �� 5   
   -   5         ��Name$ nameDoctorText��5      $
��Left=�6*   $��30��6E   $��
276,80,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��146��6�   $��29��6�   $��20(�6�   $
��nume��6�   �� 5   
   -   5        $ forNameDoctorText��5      $
��Left=�6-    �� 	MaxLength$ 30��6H   $��275,117,0,0q�6W   $��prenume��6l   $
 Wrap=�6{   $	��Top=�6�   $	��147��6�   $��29��6�   $��20(�6�   �� 5   
   -   5        $ cnpDoctorText��5      $
��Left=�6)   $ 13��6D   $��276,154,0,0q�6S   $
 Wrap=�6�   $	��Top=�6�   $	��157��6�   $��29��6�   $��20(�6�   �� 5   
   -   5        $ UniversityTextBox��5      $
��Left=�6-   $��276,228,0,0q�6H   $��universitate��6]   $
 Wrap=�6q   $	��Top=�6�   $	��123��6�   $��29��6�   $��20(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��276,193,0,0q�6D   $	��Top=�6Y   $	��123��6q   $��30��6}   $��20(�6�   �� 5   
   -   5        $ residencyDurationTextBox��5      $
��Left=�64   $ 1��6O   $��276,265,0,0q�6]   $��0��6�   $
 Wrap=�6�   $	��Top=�6�   $	��146��6�   $��29��6�   $��20(�6�   �� 5   
   -   5        $ residencyGradeTextBox��5      $
��Left=�61   $ 2��6L   $��276,302,0,0q�6Z   $��0��6�   $
 Wrap=�6�   $	��Top=�6�   $	��146��6�   $��29��6�   $��20(�6�   �� 5   
   -	   5        $��Adaugare��5      $
��Left=�6$   $��
54,423,0,0q�6?   $	��Top=�6S   $��34��6k   $��70��6w   6�   �� 5   
   -
   5         ��Name$ errorRichText��5      $��486,94,84,230q�6-   ${�False��6D   
���  ��. �5      /� 5       �� 5!   
   $��Specializare��6   $
��Left=�6'   $��
83,359,0,0q�6B   $	��Top=�6V   $��20(�6n   	� 5"   
   -   5         	�Name$ 	cardioBtn��5"      $��Cardiologist��6)   $
��Left=�6@   $��276,340,0,0q�6[   $	��Top=�6p    	� 	GroupName$
 spec��6�   $��22��6�   $	��111��6�   $��14(�6�   	� 5#   
   -   5        $ internalBtn��5#      $��Medicina Interna��6+   $
��Left=�6F   $��276,367,0,0q�6a   $	��Top=�6v   $
 spec��6�   $��22��6�   $	��134��6�   $��14(�6�   	� 5$   
   -   5        $ orthoBtn��5$      $��	Ortopedic��6(   $
��Left=�6<   $��276,395,0,0q�6W   $	��Top=�6l   $
 spec��6�   $��22��6�   $	��111��6�   $��14(�6�   5%      5&      