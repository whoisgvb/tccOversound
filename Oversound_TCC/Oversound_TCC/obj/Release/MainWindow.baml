   M S B A M L   `   `   `  ����   Oversound_TCC    Oversound_TCC.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  	OverSound�� � Title$ 	OverSound��$	��455��$	��800�� � Icon$ Resources/favicon.ico�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�$��Center=� � WindowStartupLocation$ CenterScreen=�.��� -    �Name$ gridOSmusicPlayer��$
��Left=�$	��800�����	#FF939393$	��458��$	��Top=� � RowDefinitions �� $
��106* ��� $
��123* � � ColumnDefinitions �� $
��401* ��� $
��399* �.+�r� -   	 r�Name$	 OSmusicPlayer��$��0,0,0,68q�
 r� LoadedBehavior$
 Manual=� r� UnloadedBehavior$ Close=�$��2��$��2�� r� Volume �� *Value+ �� ElementName$ SliderVolume���� -    ��Name$ MenuCima�����	#FF51BDE6$
��Left=�$��41��$	��Top=�$	��804��$��-4,0,0,0q�$��2���� -    ��Name$ ListaDeReproducao��$��Arial)����#000000$
��Left=�$	��328��$��	10,50,0,0q�$	��Top=�$	��780��
������� J� 	AllowDrop .  �� SelectedIndex$ 1��$��2��$��2����Z� �� -    ��Name$ TituloSuperior��$��Center=�$��356,10,353,0q�$
��Wrap=�$��OverSound 1.0��$	��Top=�$��13(�$
��Bold"�$��RightToLeft=�$��2���� -   $ Rvoltar�����	#FF51BDE6$
��Left=�$��30��$��
38,194,0,0q�$	��Top=�$��30�� �� RadiusY$ 21�� �� RadiusX$ 21�� J� Opacity$
 0.01Q�$��1���� -    ��Name$ 	imgRecuar��$��Resources/recuar2.png�� � ToolTip$ Voltar��$��34,199,333,27q�$��1���� -	   $ Ravancar�����	#FF51BDE6$
��Left=�$��30��$��108,194,0,0q�$	��Top=�$��30��$ 21��$ 21��$
 0.01Q�$��1���� -
   $ 
imgAvancar��$��Resources/avançar2.png��$ Avançar��$��109,199,260,27q�$��1���� -   $ imgIcone��$��16,7,367,179q�$��Resources/logo.png��$ www.oversound.com.br���� -    ��Name$ 	SlrMusica��$
��Left=�$��165,198,0,0q�$	��Top=�$	��458�� � Cursor$
 Hand�� J� OpacityMask
 ����� �� IsMoveToPointEnabled . $��2��$��1����Z� ��Z� ��Z�  � BindingGroup &   System.Windows.Data.BindingGroup  �� -   $ 
Raleatorio�����	#FF51BDE6$
��Left=�$��24��$��227,195,0,0q�$	��Top=�$��24��$ 19��$ 19��$
 0.01Q�$��1��$��1���� -   $ imgAleatorio�� J� RenderTransformOrigin$ 0,0.5&�$��Resources/aleatório.png��$ Modo Aleatório��$��232,200,153,32q�$��1��$��1��z�V� .~���  �� ScaleY$ -1Q��� �� T� �� -   $ Rrepetir�����	#FF51BDE6$
��Left=�$��24��$��254,195,0,0q�$	��Top=�$��24��$ 19��$ 19��$
 0.01Q�$��1��$��1���� -   $ Rvolume�����	#FF51BDE6$
��Left=�$��24��$��280,195,0,0q�$	��Top=�$��24��$ 19��$ 19��$
 0.01Q�$��1��$��1���� -   $ 
RPrincipal��$
��Left=�$��23��$��
75,198,0,0q�$	��Top=�$��26�����	#FF51BDE6$
 0.01Q�$��1���� -   $ SliderVolume��$
��Left=�$��
302,0,0,30q�$��Bottom=�$��73��$
 Hand�� � Maximum$ 1Q�  � SmallChange$  1Q�! �� TickFrequency$	! 0.1Q�" � Value$	" 0.5Q�$��1��$��1����Z� ��Z� ��Z�    �� -   # ��Name$# 	lblInicio��$�� ��$
��Left=�$��217,211,0,0q�$	��Top=�$	��366��$��24��$��1��$��2���� -   $ imgPause��$��Resources/pause.png��$��68,190,293,19q�$��1���� -   $ imgPlay��$��Resources/play.png��$��66,189,291,19q�$��1���� -   $ Rfechar�����	#FFFF4F4F$
��Left=�$��20��$��	376,0,0,0q�$	��Top=�$��23��$
 0.01Q�$��1���� -   $ 	btnFechar��$
��Left=�$��14��$��	381,2,0,0q�$	��Top=�$��14��$��Resources/fechar.png��$
 Sair��$
 Hand��$��1���� -   $ Rminizar�����	#FFACACAC$
��Left=�$��20��$��	353,0,0,0q�$	��Top=�$��23��$
 0.01Q�$��1���� -   $ btnMinimizar��$
��Left=�$��14��$��	357,2,0,0q�$	��Top=�$��14��$��Resources/minimizar.png��$ 	Minimizar��$
 Hand��$��1��� -   $ �Name$$ 	PrgMusica��$
��Left=�$��7��$��	0,169,0,0q�$	��Top=�$	��800�����	#FF51BDE6���	#FF939393$��2��$��1��" �� *Value+$ 	SlrMusica����Z� �� -   $ imgAleatorioAtivado��$ 0,0.5&�$%��Resources/aleatórioATIVADO.png��$ Modo Aleatório��$��232,200,153,32q�$y�	Collapsed=�$��1��$��1��z�V� .~��� $ -1Q��� �� T� �� -   $ 
imgRepetir��$��Resources/repetir.png��$ Repetir��$
 Hand��$��259,200,126,32q�$��1��$��1���� -   $ imgRepetirAtivado��$"��Resources/repetirATIVADO.png��$ Repetir��$
 Hand��$��259,200,126,32q�$y�	Collapsed=�$��1��$��1���� -   $ 	imgVolume��$��Resources/volume.png��$��285,200,99,32q�$��1��$��1���� -   $ Balao��$
��Left=�$	��116��$��	-4,28,0,0q�$	��Top=�$	��168��$��Resources/balao.png���� -    $ txtBalao��$
��Left=�$��8,46,0,0q�$
��Wrap=�% �� TextAlignment$% Center=�$4��.Para escutar, arraste músicas para o programa��$	��Top=�$��35��$	��142��
�������$ 0.5,0.5&��� -!   $ imgAvancar_aleatório��$��Resources/avançar2.png��$ Avançar��$��109,199,260,27q�$��1��$y�	Collapsed=��� -"   & ��Name$& btnLimpa��$��Limpar Músicas��$
��Left=�$��47,9,0,0q�$	��Top=�$��91�����	#FFE2E2E2��Z� 