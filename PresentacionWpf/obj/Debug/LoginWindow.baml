   M S B A M L   `   `   `  ����J  FPresentacionWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PresentacionWpfPresentacionWpf  5   	   !    PresentacionWpf.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PresentacionWpf     5   	     � Title$  LoginWindow��5   	   $��361.531��6   $	��800��6.    � WindowStyle$
 None=�6:    � 
ResizeMode$ NoResize=�6M    � WindowStartupLocation$ CenterScreen=�6c   .��5	      � $��0,0,0.333,0q�6   .+�5
   
   �� $
��Left=�6   $	��361��6+   $	��Top=�68   $	��800��6P   $��Resources/fondologin.png��6\   $��0,0,-0.333,0q�6~   ]� 5   
   $
��Left=�6   $	��361��6/   ��.  $	��Top=�6R   $	��234��6j    J� Opacity$	 0.8Q�6v   ���	#FF007BC06�   ]� 5   
   $
��Left=�6   $	��361��6/   ��.  $	��Top=�6R   $	��566��6j   $��234,0,-0.333,0q�6v   $	 0.5Q�6�   
���   �6�   �� 5   
   $
��Left=�6   $��86��6+   $	��Top=�67   $��90��6O   $��Resources/logo_black.png��6Z   $��
70,126,0,0q�6|   �� 5   
   $��LOGIN��6   $
��Left=�6    $��28��6;   $��
488,10,0,0q�6G   $	��Top=�6[   $��69��6s   $��18(�6~   $��Arial)�6�   
�������6�   �� 5   
   -   5        $��25��5      $	��Top=�6   $��25��65   $��765,4,9.667,0q�6@    � Cursor$
 Hand��6l   ��6z   Z� ��6�   Z� ��5      �� 5       �� ImageSource$  Resources/window_close.png��6   5      �� 5   
   -   5        $��25��5      $	��Top=�6   $��25��65   $��727,4,47.667,0q�6@   $
 Hand��6p   ��6~   Z� ��6�   Z� ��5      �� 5      $# Resources/window_miminize.png��6   5      �� 5   
   -   5         ��Name$ textBoxLoginUser��5      $
��Left=�6,   $��27��6G   $��
325,99,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��394��6�   $��16(�6�   
������ ���	#FFBABABA$��Email��6�   ��6�   Z� 6�   �� 5   
   $
��Left=�6   $��2��60   $��325,126,0,0q�6;   $	��Top=�6P   $	��394��6h   ���	#FFBABABA6t   �� 5   
   -   5        $ textBoxLoginPassword��5      $
��Left=�60   $��27��6K   $��325,169,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��394��6�   $��16(�6�   
������ ���	#FFBABABA$��Contraseña��6�   ��6�   Z� 6�   �� 5   
   $
��Left=�6   $��2��60   $��325,196,0,0q�6;   $	��Top=�6P   $	��394��6h   ���	#FFBABABA6t   �� 5   
   -   5        $��ACCEDER��5      $��37��6#   $	��Top=�6/   $��325,267,80.667,0q�6G   ���	#FF057505$
 Hand��6y   
������ ���	#FFBABABA6�   5      5      