   M S B A M L   `   `   `  ����F  BAssignment1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Session2Session2  5   	       Session2.ProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Session2     5   	     � Title$  ProductWindow��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5
      �  � RowDefinitions 5   
   �� 5      $
��1.3* �6   6,   �� 5      $��9* �6   6*    � ColumnDefinitions 5   
   �� 5      $
��4.5* �6   6.   �� 5      $
��7.5* �6   6.   .+�5   
   �� $��0��6   $��1��6"   
�������$
��Left=�6I    �� Orientation$ 
Horizontal=�6d   .+�5      �� $��10q�6   $��Product Name��6    69   �� 5      -   5         ��Name$ txtProductNameSearch��5      $��10q�64   $	��120��6@   ��5      ��  �� Path$ ProductName� �� Mode$ OneWay=�5      �� 5      $��10q�6   $��
Unit Price��6    67   �� 5      -   5        $ txtPriceSearch��5      $��10q�6.   $��80��6:   ��5      �� $ 	UnitPrice�$ OneWay=�.��6E   5      �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6(   $��10q�69   $��50��6E   
����d�6�   5      �� 5   
   
����ح�$ Vertical=�6-   $��1��6D   $��0��6Q   .+�5       �� $��	Category ��6   6*   �� 5!      -   5        	 ��Name$	 cboCategoryId��5!      
 �� DisplayMemberPath$
 CategoryName��5"       �� SelectedValuePath$ 
CategoryId��5#       �� SelectedValue 5$      �� $ 
CategoryId�$ OneWay=� � DataContext 5%      ��  �� ElementName$ ListProduct��$ SelectedItem�5&      �� 5'      $��Product Name��6   5(      �� 5)      -   5        $ txtProductName��5)      ��5*      �� $ ProductName�$ OneWay=� 5+      �� $ ListProduct��$ SelectedItem�.��6Y   5,      �� 5-      $��Weight��6   6'   �� 5.      -   5        $ 	txtWeight��5.      ��5/      �� $ Weight�$ OneWay=� 50      �� $ ListProduct��$ SelectedItem�.��6Y   51      �� 52      $��
Unit Price��6   6+   �� 53      -   5        $ txtUnitPrice��53      ��54      �� $ 	UnitPrice�$ OneWay=� 55      �� $ ListProduct��$ SelectedItem�.��6Y   56      �� 57      $��Unit In Stock��6   6.   �� 58      -   5        $ txtUnitInStock��58      ��59      �� $ UnitInStock�$ OneWay=� 5:      �� $ ListProduct��$ SelectedItem�.��6[   5;      5=      �� 5>   
   $��0��6   $��0��6"   $ 
Horizontal=�62   $
��Left=�6K   .+�5?      �� -	   5        $ 	btnInsert��5?      $��10q�6(   $��80��64   $��Insert��6?   6j   �� 5@      -
   5        $ 	btnUpdate��5@      $��10q�6(   $��80��64   $��Update��6?   6j   �� 5A      -   5        $ 	btnDelete��5A      $��10q�6(   $��80��64   $��Delete��6?   6j   5C      �� 5D   
   $��2��6   $��0��6"   $ 
Horizontal=�62   $
��Left=�6K   .+�5E      �� $��Author: Nguyen Lan Anh��6   $��Bottom=�64   $	��300��6O   6_   5F      �� 5G   
   -   5         ��Name$ ListProduct��5G   0   $��1��6   $��1��6     �� View 5H      �� 5I      .P�5J      �� $��
Product Id��6%    �� Width$ 60��69    �� DisplayMemberBinding 6D   �� $ 	ProductId�6v   �� 5K      $��Category��6%   $ 60��67    6B   �� $ Category.CategoryName�6�   �� 5L      $��Product Name��6%   $	 100��6;    6G   �� $ ProductName�6{   �� 5M      $��Weight��6%   $ 50��65    6@   �� $ Weight�6o   �� 5N      $��	UnitPrice��6%   $	 100��68    6D   �� $ 	UnitPrice�6v   �� 5O      $��UnitInStock��6%   $	 100��6:    6F   �� $ UnitInStock�6z   5P      5R      5T      5U      