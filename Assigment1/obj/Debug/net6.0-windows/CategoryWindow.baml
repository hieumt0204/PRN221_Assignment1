   M S B A M L   `   `   `  ����F  BAssignment1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Session2Session2  5   	       Session2.CategoryWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Session2     5   	     � Title$  CategoryWindow��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*   �� 5      $��3* �6   6*   �� 5      $
��0.4* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   
����ح�.+�5      �� $��Category Name��6   $��30��6,   6:   �� 5      -   5         ��Name$ txtCategoryName��5   "   $��30��6   ��5      ��  �� Path$ CategoryName� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ listCategory��$ SelectedItem�6\   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� -   5        	 ��Name$	 	btnInsert��5      $	��Add��6)   $��10q�67   $	��100��6C   6i   �� 5      -   5        $	 	btnUpdate��5      $��Update��6)   $��10q�6:   $	��100��6F   6l   �� 5      -   5        $	 	btnDelete��5      $��Delete��6)   $��10q�6:   $	��100��6F   6m   �� 5      -   5        $	 btnBack��5   ,   $��Back to Main��6   $��10q�6=   $	��100��6I   6n   5      �� 5   
   -   5        
 ��Name$
 listCategory��5      $��2��6)    �� View 5      �� 5      .P�5      �� $��Category Id��6%    �� Width$ 80��6:    �� DisplayMemberBinding 6E   �� $ 
CategoryId�6y   �� 5       $��Category Name��6%   $	 100��6<    6H   �� $ CategoryName�6}   5!      5$      � 5%   
   $��Bottom=�6   .+�5&      �� $��/Images/main.png��6   $��Center=�6.   $��Center=�6K   $	��354��6f   5(      �� 5)   
   $ 
Horizontal=�6   $
��Left=�6.   $��3��6I   .+�5*      �� $��Author: Mai Trong Hieu��6   67   5+      5,      5-      