   M S B A M L   `   `   `  ����N  JEssensysHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EssensysHospitalWPF.PagesEssensysHospitalWPF.Pages  5   	   *    $EssensysHospitalWPF.Pages.EditDoctor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:EssensysHospitalWPF.Pages     5   	     � Title$  
EditDoctor��5   	   $	��450��6   $	��800��6)   .��5	      � ���	#FF13BCD6.+�5
   
   �� $`��ZScrie ID-ul doctorului caruia vrei sa ii editezi detaliile si modifica urmatoarele campuri��6   $
��Left=�6u   $��	60,46,0,0q�6�   $	��Top=�6�   $��24��6�   $	��477��6�   �� 5   
   -   5         ��Name$ EditDoctorDetails��5      $��Salvare��6,   $
��Left=�6>   $��
70,225,0,0q�6Y   $	��Top=�6m   $��31��6�   $��58��6�   6�   �� 5   
   $
��Nume��6   $
��Left=�6   $��
61,102,0,0q�6:   $	��Top=�6N    J� RenderTransformOrigin$ 0.316,0.231&�6f   �� 5   
   $��Prenume��6   $
��Left=�6"   $��
60,129,0,0q�6=   $	��Top=�6Q   $ 0.316,0.231&�6i   �� 5   
   $��ID��6   $
��Left=�6   $��	60,75,0,0q�68   $	��Top=�6K   $ 0.316,0.231&�6c   �� 5   
   $P��J(Am pastrat editarea doar pentru nume si prenume, e identic pentru restul)��6   $
��Left=�6e   $��
39,369,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ backBtn��5      $��Inapoi��6"   $
��Left=�63   $��706,369,0,0q�6N   $	��Top=�6c   $��32��6{   $��71��6�   6�   �� 5   
   -   5         ��Name$ errorRichText��5      $��428,75,103,255q�6-   ${�False��6E   
���  ��. �5      /� 5      �� 5   
   $
��Left=�6   $��
122,79,0,0q�6-   $��TextBox��6A    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��120��6|   �� 5   
   -   5         ��Name$ forNameTextBox��5      $
��Left=�6*   $��122,133,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ 	idTextBox��5       �� 	MaxLength$ 3��6%   $
��Left=�63   $��
122,79,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ nameTextBox��5      $
��Left=�6'   $��122,106,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   5      5      