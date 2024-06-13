 <Grid>
     <DataGrid BorderThickness="0"
               GridLinesVisibility="None"
               ItemsSource="{Binding DataItems}" 
               AutoGenerateColumns="True"
               HorizontalAlignment="Stretch" 
               VerticalAlignment="Stretch"
               >
         <DataGrid.Resources>
             <!-- Define the Cell Style -->
             <Style TargetType="DataGridCell">
                 <Setter Property="BorderThickness" Value="0.1"/>
                 <Setter Property="BorderBrush" Value="DarkGray"/>
             </Style>
             <Style TargetType="DataGridColumnHeader">
                 <Setter Property="BorderThickness" Value="0.1"/>
                 <Setter Property="BorderBrush" Value="DarkGray"/>
                 <Setter Property="Padding" Value="3"/>
                 <Style.Triggers>
                     <!-- Trigger to change background color when mouse is over -->
                     <Trigger Property="IsMouseOver" Value="True">
                         <Setter Property="Background" Value="SkyBlue"/>
                     </Trigger>
                 </Style.Triggers>
             </Style>
         </DataGrid.Resources>
     </DataGrid>
 </Grid>
