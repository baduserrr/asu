Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Text

Public Class MAINFLAT

#Region "VARIABLE DECLARE"
    Dim First_Set As Boolean = True
    Dim Incr_ As Boolean
    Dim Opacity_ As Decimal
    Dim MAX_1 As Decimal = 999999999
    Dim MIN_1 As Decimal = 1
    Dim INC_1 As Decimal = 1
    Dim INC_2 As Decimal = 0.01
    Dim DEC_1 As Integer = 2
    Dim N_ As Integer
    Dim X1 As Integer = 0
    Dim X2 As Integer = 150
    Dim X3 As Integer = 300
    Dim Txt_1(100) As String
    Dim NM_(100) As NumericUpDown
    Dim VerifCode As String = "2198Arch-MAD"

    'Color
    Dim HeaderColor As System.Drawing.Color = System.Drawing.Color.FromArgb(20, 25, 30)
    Dim BackgroundColor As System.Drawing.Color = System.Drawing.Color.FromArgb(31, 35, 46)
    Dim BTN_A As System.Drawing.Color = System.Drawing.Color.FromArgb(39, 45, 7) '39, 45, 7
    Dim DISBTN_A As System.Drawing.Color = System.Drawing.Color.FromArgb(81, 77, 6) '81, 77, 6
    Dim FNT_A As System.Drawing.Color = System.Drawing.Color.FromArgb(200, 200, 200)
    Dim FNT_B As System.Drawing.Color = System.Drawing.Color.FromArgb(150, 147, 76)
    Dim Warna1 As System.Drawing.Color = System.Drawing.Color.FromArgb(252, 180, 20)
    Dim Warna2 As System.Drawing.Color = System.Drawing.Color.FromArgb(203, 27, 74)
    Dim Warna3 As System.Drawing.Color = System.Drawing.Color.FromArgb(2, 125, 140)
    Dim Warna4 As System.Drawing.Color = System.Drawing.Color.FromArgb(75, 92, 118) 'Panel XP
    Dim Warna5 As System.Drawing.Color = System.Drawing.Color.FromArgb(129, 150, 190)
    Dim Warna6 As System.Drawing.Color = System.Drawing.Color.FromArgb(46, 189, 161)
#End Region

#Region "STARTUP"
    Private Sub STARTUP(sender As Object, e As EventArgs) Handles MyBase.Activated
        If First_Set = True Then
            'MACHINATION
            STR.Text = STRR()
            AGI.Text = AGII()
            INT.Text = INTT()
            DMG.Text = DMGS()
            HP.Text = HPRESULT()
            MP.Text = MPRESULT()
            HPR.Text = HPRR()
            MPR.Text = MPRR()
            BNS()

            'Header
            Me.TopMost = True
            MUSICC.BackColor = HeaderColor
            ONTOP.BackColor = HeaderColor
            EXITBUTT.BackColor = HeaderColor
            HEADPANEL.BackColor = HeaderColor
            'Background
            Me.BackColor = BackColor
            PP1.BackColor = BackgroundColor
            PP2.BackColor = BackgroundColor
            PP3.BackColor = BackgroundColor
            'Button
            PANELA.Cursor = Cursors.Hand
            PANELB.Cursor = Cursors.Hand
            PANELC.Cursor = Cursors.Hand
            PANELA.BackColor = BTN_A
            PANELB.BackColor = DISBTN_A
            PANELC.BackColor = DISBTN_A
            AAA.ForeColor = FNT_A
            BBB.ForeColor = FNT_B
            CCC.ForeColor = FNT_B

            'PANEL
            PANEL_1.BackColor = Warna1
            For Each ctrl As Control In PANEL_1.Controls
                If TypeOf ctrl Is Label Then
                    ctrl.BackColor = Warna1
                End If
            Next
            PANEL_2.BackColor = Warna2
            For Each ctrl As Control In PANEL_2.Controls
                If TypeOf ctrl Is Label Then
                    ctrl.BackColor = Warna2
                End If
            Next
            PANEL_3.BackColor = Warna3
            For Each ctrl As Control In PANEL_3.Controls
                If TypeOf ctrl Is Label Then
                    ctrl.BackColor = Warna3
                End If
            Next
            For Each textb As TextBox In PANEL_3.Controls.OfType(Of TextBox)()
                textb.ReadOnly = True
            Next

            'BASE SETUP
            'Maximum
            LVL0.Maximum = MAX_1
            HP0.Maximum = MAX_1
            HPR0.Maximum = MAX_1
            MPR0.Maximum = MAX_1
            DMG0.Maximum = MAX_1
            DEF0.Maximum = MAX_1
            DICE1.Maximum = MAX_1
            DICE2.Maximum = MAX_1
            BONUS0.Maximum = MAX_1
            CD0.Maximum = MAX_1
            'Minimum
            LVL0.Minimum = MIN_1
            'Value
            'Decimal
            HPR0.DecimalPlaces = DEC_1
            MPR0.DecimalPlaces = DEC_1
            CD0.DecimalPlaces = DEC_1
            'Increment
            HPR0.Increment = INC_2
            MPR0.Increment = INC_2
            CD0.Increment = INC_2

            'STATS SETUP
            'Maximum
            STR1.Maximum = MAX_1
            STR2.Maximum = MAX_1
            AGI1.Maximum = MAX_1
            AGI2.Maximum = MAX_1
            INT1.Maximum = MAX_1
            INT2.Maximum = MAX_1
            'Minimum
            LVL0.Minimum = MIN_1
            'Value
            'Decimal
            STR2.DecimalPlaces = DEC_1
            AGI2.DecimalPlaces = DEC_1
            INT2.DecimalPlaces = DEC_1
            'Increment
            STR2.Increment = INC_2
            AGI2.Increment = INC_2
            INT2.Increment = INC_2

            'RESULT SETUP
            DMG.TextAlign = HorizontalAlignment.Center
            DPS.TextAlign = HorizontalAlignment.Center
            BDMG.TextAlign = HorizontalAlignment.Center

            'SAVING SETUP
            Txt_1(1) = "Level = "
            Txt_1(2) = "HP Base = "
            Txt_1(3) = "HP Regeneration Base = "
            Txt_1(4) = "MP Regeneration Base = "
            Txt_1(5) = "Damage Base = "
            Txt_1(6) = "Dice = "
            Txt_1(7) = "per Dice = "
            Txt_1(8) = "Defend Base = "
            Txt_1(9) = "Attack Speed Base = "
            Txt_1(10) = "Bonus Damage = "
            Txt_1(11) = "Primary Attribute = "
            Txt_1(12) = "Strength Base = "
            Txt_1(13) = "Strength per level = "
            Txt_1(14) = "Agility Base = "
            Txt_1(15) = "Agility per level = "
            Txt_1(16) = "Intelligent Base = "
            Txt_1(17) = "Intelligent per level = "
            NM_(1) = LVL0
            NM_(2) = HP0
            NM_(3) = HPR0
            NM_(4) = MPR0
            NM_(5) = DMG0
            NM_(6) = DICE1
            NM_(7) = DICE2
            NM_(8) = DEF0
            NM_(9) = CD0
            NM_(10) = BONUS0
            NM_(12) = STR1
            NM_(13) = STR2
            NM_(14) = AGI1
            NM_(15) = AGI2
            NM_(16) = INT1
            NM_(17) = INT2

            'XP Required Setup
            PANELXP.BackColor = Warna4
            For Each ctrl As Control In PANELXP.Controls
                If TypeOf ctrl Is Label Then
                    ctrl.BackColor = Warna4
                End If
            Next
            XPRequiredData.BackgroundColor = Warna5
            XPRequiredData.GridColor = Warna4
            CoLevel.DefaultCellStyle.BackColor = Warna5
            CoLevel.DefaultCellStyle.SelectionBackColor = Warna6
            CoXP.DefaultCellStyle.BackColor = Warna5
            CoXP.DefaultCellStyle.SelectionBackColor = Warna6

            TABF.Maximum = MAX_1
            TABF.Value = 200
            CSTNF.Maximum = MAX_1
            CSTNF.DecimalPlaces = DEC_1
            LVLF.Maximum = MAX_1
            LVLF.DecimalPlaces = DEC_1
            PREVF.Maximum = MAX_1
            PREVF.DecimalPlaces = DEC_1
            TABF.Maximum = MAX_1
            TABF.Increment = 100D
            TABF.Minimum = 0
            LVLMIN.Maximum = MAX_1
            LVLMIN.Minimum = 2
            LVLMAX.Maximum = MAX_1
            First_Set = False
        Else
            Exit Sub
        End If
    End Sub

    Private Sub OpacityBar_Scroll(sender As Object, e As EventArgs) Handles OpacityBar.Scroll
        Opacity_ = OpacityBar.Value / 100
        If Opacity_ = 0 Then
            Opacity_ = 0.05
        End If
        Me.Opacity = Opacity_
    End Sub

    Private Sub ONTOP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ONTOP.CheckedChanged
        If ONTOP.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub MUSICC_CheckedChanged(sender As Object, e As EventArgs) Handles MUSICC.CheckedChanged
        If MUSICC.Checked = True Then
            My.Computer.Audio.Play(My.Resources.Backsound, AudioPlayMode.BackgroundLoop)
        Else
            My.Computer.Audio.Stop()
        End If
    End Sub
#End Region

#Region "FLAT INITIALIZING"
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub DOWND(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub MOVED(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub UPD(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub


    Private Sub PDOWN(sender As Object, e As MouseEventArgs) Handles HEADPANEL.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub PMOVE(sender As Object, e As MouseEventArgs) Handles HEADPANEL.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PUP(sender As Object, e As MouseEventArgs) Handles HEADPANEL.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
    '========================================================================================================//

    Private Sub EXITBUTT_CLICK(sender As Object, e As EventArgs) Handles EXITBUTT.Click
        Application.Exit()
        End
    End Sub
#End Region

#Region "BUTTON"
    Function BTN1_SELECT()
        Dim lc As Boolean = True
        Do
            Dim i As Integer = SELECT_BTN.Left
            Dim l As Integer
            If i > X1 Then
                l = i - 1
            Else
                l = i + 1
            End If
            SELECT_BTN.Left = l
            If l = X1 Then
                lc = False
            End If
        Loop Until lc = False
        PANELA.BackColor = BTN_A
        PANELB.BackColor = DISBTN_A
        PANELC.BackColor = DISBTN_A
        AAA.ForeColor = FNT_A
        BBB.ForeColor = FNT_B
        CCC.ForeColor = FNT_B
        BTN_OPEN.Enabled = True
        BTN_SAVE.Enabled = True
        Me.PP0.SelectedTab = PP1
        Return 0
    End Function

    Function BTN2_SELECT()
        Dim lc As Boolean = True
        Do
            Dim i As Integer = SELECT_BTN.Left
            Dim l As Integer
            If i > X2 Then
                l = i - 1
            Else
                l = i + 1
            End If
            SELECT_BTN.Left = l
            If l = X2 Then
                lc = False
            End If
        Loop Until lc = False
        PANELA.BackColor = DISBTN_A
        PANELB.BackColor = BTN_A
        PANELC.BackColor = DISBTN_A
        AAA.ForeColor = FNT_B
        BBB.ForeColor = FNT_A
        CCC.ForeColor = FNT_B
        BTN_OPEN.Enabled = False
        BTN_SAVE.Enabled = False
        Me.PP0.SelectedTab = PP2
        Return 0
    End Function

    Function BTN3_SELECT()
        Dim lc As Boolean = True
        Do
            Dim i As Integer = SELECT_BTN.Left
            Dim l As Integer
            If i > X3 Then
                l = i - 1
            Else
                l = i + 1
            End If
            SELECT_BTN.Left = l
            If l = X3 Then
                lc = False
            End If
        Loop Until lc = False
        PANELA.BackColor = DISBTN_A
        PANELB.BackColor = DISBTN_A
        PANELC.BackColor = BTN_A
        AAA.ForeColor = FNT_B
        BBB.ForeColor = FNT_B
        CCC.ForeColor = FNT_A
        BTN_OPEN.Enabled = False
        BTN_SAVE.Enabled = False
        Me.PP0.SelectedTab = PP3
        Return 0
    End Function

    Private Sub ACSE(sender As Object, e As EventArgs) Handles AAA.MouseEnter
        AAA.ForeColor = FNT_A
    End Sub
    Private Sub ACSL(sender As Object, e As EventArgs) Handles AAA.MouseLeave
        If PANELA.BackColor = BTN_A Then
            AAA.ForeColor = FNT_A
        Else
            AAA.ForeColor = FNT_B
        End If
    End Sub
    Private Sub ACS(sender As Object, e As EventArgs) Handles AAA.Click
        BTN1_SELECT()
    End Sub
    Private Sub PANELA_MouseEnter(sender As Object, e As EventArgs) Handles PANELA.MouseEnter
        AAA.ForeColor = FNT_A
    End Sub
    Private Sub PANELA_MouseLeave(sender As Object, e As EventArgs) Handles PANELA.MouseLeave
        If PANELA.BackColor = BTN_A Then
            AAA.ForeColor = FNT_A
        Else
            AAA.ForeColor = FNT_B
        End If
    End Sub
    Private Sub ACD(sender As Object, e As EventArgs) Handles PANELA.Click
        BTN1_SELECT()
    End Sub


    Private Sub BCSE(sender As Object, e As EventArgs) Handles BBB.MouseEnter
        BBB.ForeColor = FNT_A
    End Sub
    Private Sub BCSL(sender As Object, e As EventArgs) Handles BBB.MouseLeave
        If PANELB.BackColor = BTN_A Then
            BBB.ForeColor = FNT_A
        Else
            BBB.ForeColor = FNT_B
        End If
    End Sub
    Private Sub PANELB_MouseEnter(sender As Object, e As EventArgs) Handles PANELB.MouseEnter
        BBB.ForeColor = FNT_A
    End Sub
    Private Sub PANELB_MouseLeave(sender As Object, e As EventArgs) Handles PANELB.MouseLeave
        If PANELB.BackColor = BTN_A Then
            BBB.ForeColor = FNT_A
        Else
            BBB.ForeColor = FNT_B
        End If
    End Sub
    Private Sub BCS(sender As Object, e As EventArgs) Handles BBB.Click
        BTN2_SELECT()
    End Sub
    Private Sub BCD(sender As Object, e As EventArgs) Handles PANELB.Click
        BTN2_SELECT()
    End Sub


    Private Sub CCSE(sender As Object, e As EventArgs) Handles CCC.MouseEnter
        CCC.ForeColor = FNT_A
    End Sub

    Private Sub CCSL(sender As Object, e As EventArgs) Handles CCC.MouseLeave
        If PANELC.BackColor = BTN_A Then
            CCC.ForeColor = FNT_A
        Else
            CCC.ForeColor = FNT_B
        End If
    End Sub
    Private Sub PANELC_MouseEnter(sender As Object, e As EventArgs) Handles PANELC.MouseEnter
        CCC.ForeColor = FNT_A
    End Sub
    Private Sub PANELC_MouseLeave(sender As Object, e As EventArgs) Handles PANELC.MouseLeave
        If PANELC.BackColor = BTN_A Then
            CCC.ForeColor = FNT_A
        Else
            CCC.ForeColor = FNT_B
        End If
    End Sub
    Private Sub CCS(sender As Object, e As EventArgs) Handles CCC.Click
        BTN3_SELECT()
    End Sub
    Private Sub CCD(sender As Object, e As EventArgs) Handles PANELC.Click
        BTN3_SELECT()
    End Sub
#End Region

#Region "MAIN CODE"
    Dim Bonus As Decimal
    Dim DMGA As String
    Dim DMGB As String
    Dim WDM(1) As String

    'Function ============================================================================

    Function HPRESULT() As String
        'HP Final Formula = HP Base + (Strenght * 25) + (Item bonus)
        HPRESULT = Math.Round((HP0.Value) + (Val(STR.Text) * 25))
    End Function

    Function MPRESULT() As String
        'Mana Final Formula = (Intelligent * 15)
        MPRESULT = Math.Round(Val(INT.Text) * 15)
    End Function

    Function HPRR() As String
        'Final HP Regen = (Regen Base + (0.05 * STR) + Item bonus) * Ability Bonus
        HPRR = HPR0.Value + (0.05 * Val(STR.Text))
    End Function

    Function MPRR() As String
        'Final MP regen = Mp regen base + (0.05 * INT) + Ability bonus + (Item bonus * (0.01 + (0.05 + INT))
        MPRR = MPR0.Value + (0.05 * Val(INT.Text))
    End Function

    '' Defense ============================================================================
    Function DEFF() As String
        'Final Armor = Base Armor + (0.3 * AGI) + (0.3 * Agi Bonus) + Item bonus + Ability Bonus
        DEFF = Math.Round(DEF0.Value + (0.3 * Val(AGI.Text)))
    End Function

    '' Attack rate ============================================================================
    Function ATT() As String
        'Final Cooldwon = Base cooldown / (1 + (0.02 * Agi) + item bonus + ability bonus
        ATT = Val(CD0.Value) / (1 + (0.02 * Val(AGI.Text)))
    End Function

    '' Stats Function ============================================================================
    Function STRR() As String
        STRR = STR1.Value + (STR2.Value * (LVL0.Value - 1))
    End Function

    Function INTT() As String
        INTT = INT1.Value + (INT2.Value * (LVL0.Value - 1))
    End Function

    Function AGII() As String
        AGII = AGI1.Value + (AGI2.Value * (LVL0.Value - 1))
    End Function

    '' Damage ============================================================================
    Function BNS() As String
        If STR0.Checked = True Then
            Bonus = Math.Round((0.25 * (Val(STR.Text) * BONUS0.Value)))
            BDMG.Text = Val(Bonus)
        ElseIf INT0.Checked = True Then
            Bonus = Math.Round((0.25 * (Val(INT.Text) * BONUS0.Value)))
            BDMG.Text = Val(Bonus)
        ElseIf AGI0.Checked = True Then
            Bonus = Math.Round((0.25 * (Val(AGI.Text) * BONUS0.Value)))
            BDMG.Text = Val(Bonus)
        End If
        Return 0
    End Function

    Function DMGS() As String
        If STR0.Checked = True Then
            BNS()
        ElseIf INT0.Checked = True Then
            BNS()
        ElseIf AGI0.Checked = True Then
            BNS()
        Else
            BDMG.Text = 0
        End If
        If BDMG.Text = 0 Then
            BDMG.Text = ""
            DMGA = DMG0.Value + DICE2.Value
            DMGB = DMG0.Value + (DICE1.Value * DICE2.Value)
            WDM(0) = DMGA
            WDM(1) = DMGB
            DMGS = Join(WDM, " -- ")
            DPS.Text = ((WDM(0) + WDM(1)) / 2) / (Val(CD.Text))
        Else
            DMGA = (DMG0.Value + Bonus) + DICE2.Value
            DMGB = (DMG0.Value + Bonus) + (DICE1.Value * DICE2.Value)
            WDM(0) = DMGA
            WDM(1) = DMGB
            DMGS = Join(WDM, " -- ")
            DPS.Text = ((WDM(0) + WDM(1)) / 2) / (Val(CD.Text))
        End If
    End Function

    '============================================================================

    ''                      Ruang Pemisah
    ''
    ''              Ruang Pemisah
    ''
    ''      Ruang Pemisah
    ''
    ''Ruang Pemisah

    Private Sub LVL0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVL0.ValueChanged
        STR.Text = STRR()
        AGI.Text = AGII()
        INT.Text = INTT()
        DMG.Text = DMGS()
        HP.Text = HPRESULT()
        MP.Text = MPRESULT()
        HPR.Text = HPRR()
        MPR.Text = MPRR()
    End Sub

    Private Sub HP0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HP0.ValueChanged
        STR.Text = STRR()
        HP.Text = HPRESULT()
    End Sub

    Private Sub MP0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        INT.Text = STRR()
        MP.Text = MPRESULT()
    End Sub

    Private Sub HPR0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HPR0.ValueChanged
        HPR.Text = HPRR()
    End Sub

    Private Sub MPR0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MPR0.ValueChanged
        MPR.Text = MPRR()
    End Sub

    Private Sub DMG0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DMG0.ValueChanged
        DMG.Text = DMGS()
    End Sub

    Private Sub DICE1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DICE1.ValueChanged
        DMG.Text = DMGS()
    End Sub

    Private Sub DICE2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DICE2.ValueChanged
        DMG.Text = DMGS()
    End Sub

    Private Sub BONUS0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BONUS0.ValueChanged
        DMG.Text = DMGS()
    End Sub

    Private Sub CD0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CD0.ValueChanged
        CD.Text = ATT()
        DMG.Text = DMGS()
    End Sub

    'Stats Code ===========================================================================
    Private Sub STR0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STR0.CheckedChanged
        If STR0.Checked = True Then
            INT0.Checked = False
            AGI0.Checked = False
            DMG.Text = DMGS()
        ElseIf STR0.Checked = False Then
            DMG.Text = DMGS()
        End If
    End Sub

    Private Sub INT0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INT0.CheckedChanged
        If INT0.Checked = True Then
            STR0.Checked = False
            AGI0.Checked = False
            DMG.Text = DMGS()
        Else
            DMG.Text = DMGS()
        End If
    End Sub

    Private Sub AGI0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGI0.CheckedChanged
        If AGI0.Checked = True Then
            STR0.Checked = False
            INT0.Checked = False
            DMG.Text = DMGS()
        Else
            DMG.Text = DMGS()
        End If
    End Sub

    'Strength = HP
    Private Sub STR1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STR1.ValueChanged
        STR.Text = STRR()
        HP.Text = HPRESULT()
        HPR.Text = HPRR()
        BNS()
    End Sub

    Private Sub STR2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STR2.ValueChanged
        STR.Text = STRR()
        HP.Text = HPRESULT()
        HPR.Text = HPRR()
        BNS()
    End Sub

    'Intelligent = MP
    Private Sub INT1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INT1.ValueChanged
        INT.Text = INTT()
        MP.Text = MPRESULT()
        MPR.Text = MPRR()
        BNS()
    End Sub

    Private Sub INT2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INT2.ValueChanged
        INT.Text = INTT()
        MP.Text = MPRESULT()
        MPR.Text = MPRR()
        BNS()
    End Sub

    'Agility = Damage
    Private Sub AGI1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGI1.ValueChanged
        AGI.Text = AGII()
        DEF.Text = DEFF()
        CD.Text = ATT()
        BNS()
    End Sub

    Private Sub AGI2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGI2.ValueChanged
        AGI.Text = AGII()
        DEF.Text = DEFF()
        CD.Text = ATT()
        BNS()
    End Sub

    Private Sub DEF0_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEF0.ValueChanged
        AGI.Text = AGII()
        DEF.Text = DEFF()
        CD.Text = ATT()
        BNS()
    End Sub

    Private Sub CD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CD.TextChanged
        AGI.Text = AGII()
        DEF.Text = DEFF()
        CD.Text = Val(ATT()).ToString("0.00")
    End Sub
#End Region

#Region "SAVING"

    Private Sub BTN_OPEN_Click(sender As Object, e As EventArgs) Handles BTN_OPEN.Click
        'First Open File
        Using fld As New OpenFileDialog()
            fld.Filter = "Stats files (*.stts)|*.stts|All files (*.*)|*.*"
            fld.FilterIndex = 1
            If fld.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim xvie_ As String = System.IO.Path.GetExtension(fld.FileName)
                Dim STTS_F As String
                STTS_F = fld.FileName()
                If xvie_ = ".stts" Then
                    Dim RF_ As Boolean
                    Dim Searc_W As Boolean = True
                    Dim Searc_T As Integer = 0
                    Dim Txt_2(100) As String
                    Dim Txt_3() As String
                    Dim Context As Decimal
                    Dim Context2 As String
                    'Check If Its The right file ?
                    For Each VerifLine As String In File.ReadLines(STTS_F)
                        If VerifLine.Contains(VerifCode) Then
                            RF_ = True
                            Exit For
                        Else
                            RF_ = False
                        End If
                    Next
                    'Opening Progress
                    If RF_ = True Then
                        For Each Line As String In File.ReadLines(STTS_F)
                            Searc_T += 1
                            If Line.Contains(Txt_1(Searc_T)) Then
                                'Run Numbering
                                Txt_2(Searc_T) = Line
                                Txt_3 = Split(Line, " = ")
                                'Cari Numeric
                                If Searc_T < 11 Then
                                    Context = Convert.ToDecimal(Txt_3(1))
                                    NM_(Searc_T).Value = Context
                                    'Primary Attribute
                                ElseIf Searc_T = 11 Then
                                    Context2 = (Txt_3(1))
                                    If Context = "1" Then
                                        STR0.Checked = True
                                    ElseIf Context = "2" Then
                                        AGI0.Checked = True
                                    ElseIf Context = "3" Then
                                        INT0.Checked = True
                                    Else
                                        STR0.Checked = False
                                        AGI0.Checked = False
                                        INT0.Checked = False
                                    End If
                                    'Attribute Value
                                ElseIf Searc_T < 17 Then
                                    Context = Convert.ToDecimal(Txt_3(1))
                                    NM_(Searc_T).Value = Context
                                ElseIf Searc_T = 17 Then
                                    Context = Convert.ToDecimal(Txt_3(1))
                                    NM_(Searc_T).Value = Context
                                    STR.Text = STRR()
                                    AGI.Text = AGII()
                                    INT.Text = INTT()
                                    DMG.Text = DMGS()
                                    HP.Text = HPRESULT()
                                    MP.Text = MPRESULT()
                                    HPR.Text = HPRR()
                                    MPR.Text = MPRR()
                                    BNS()
                                    Searc_W = False
                                End If
                            End If
                            If Searc_W = False Then
                                xvie_ = Nothing
                                STTS_F = Nothing
                                Searc_W = Nothing
                                Searc_T = 0
                                Txt_2 = Nothing
                                Txt_3 = Nothing
                                Context = Nothing
                                Context2 = Nothing
                                Exit For
                            End If
                        Next
                    ElseIf RF_ = False Then
                        MsgBox("Broken Stats File")
                    End If
                Else
                    MessageBox.Show("Wrong File, not Stats file")
                End If
            End If
        End Using
    End Sub

    Private Sub BTN_SAVE_Click(sender As Object, e As EventArgs) Handles BTN_SAVE.Click
        Using svd As New SaveFileDialog()
            svd.Filter = "Stats files (*.stts)|*.stts|All files (*.*)|*.*"
            svd.FilterIndex = 1
            svd.ShowDialog()
            Dim STATS_F As String = svd.FileName
            If STATS_F <> "" Then
                System.IO.File.Create(STATS_F).Dispose()

                Dim addInfo As New System.IO.StreamWriter(STATS_F)
                addInfo.WriteLine(Txt_1(1) & LVL0.Value)
                addInfo.WriteLine(Txt_1(2) & HP0.Value)
                addInfo.WriteLine(Txt_1(3) & HPR0.Value)
                addInfo.WriteLine(Txt_1(4) & MPR0.Value)
                addInfo.WriteLine(Txt_1(5) & DMG0.Value)
                addInfo.WriteLine(Txt_1(6) & DICE1.Value)
                addInfo.WriteLine(Txt_1(7) & DICE2.Value)
                addInfo.WriteLine(Txt_1(8) & DEF0.Value)
                addInfo.WriteLine(Txt_1(9) & CD0.Value)
                addInfo.WriteLine(Txt_1(10) & BONUS0.Value)
                Dim Primary As Integer
                If STR0.Checked = True Then
                    Primary = 1
                ElseIf AGI0.Checked = True Then
                    Primary = 2
                ElseIf INT0.Checked = True Then
                    Primary = 3
                End If
                addInfo.WriteLine(Txt_1(11) & Primary)
                addInfo.WriteLine(Txt_1(12) & STR1.Value)
                addInfo.WriteLine(Txt_1(13) & STR2.Value)
                addInfo.WriteLine(Txt_1(14) & AGI1.Value)
                addInfo.WriteLine(Txt_1(15) & AGI2.Value)
                addInfo.WriteLine(Txt_1(16) & INT1.Value)
                addInfo.WriteLine(Txt_1(17) & INT2.Value)
                addInfo.WriteLine("")
                addInfo.WriteLine("")
                addInfo.WriteLine(VerifCode)
                addInfo.Close()
            End If
        End Using
    End Sub
#End Region

#Region "XP CALCULATOR"
    'EXP CALCULATOR
    ' Experience required = "Previous value" * "Previous value factor" + "Level" * "Level factor" + "Constant factor"

    Function XPREQ()
        Dim StartLVL As Decimal = LVLMIN.Value
        Dim FinishLVL As Decimal = LVLMAX.Value
        Dim CONValue As Decimal = CSTNF.Value
        Dim PREVValue As Decimal = PREVF.Value
        Dim LVLValue As Decimal = LVLF.Value
        Dim XPValue(FinishLVL) As String
        Dim LVLIndex As Decimal = StartLVL - 1
        XPRequiredData.Rows.Clear()
        Do
            LVLIndex += 1
            If LVLIndex = StartLVL Then
                XPValue(LVLIndex) = TABF.Value
                If XPValue(LVLIndex) <= Integer.MaxValue Then
                    XPValue(LVLIndex) = Convert.ToDecimal(XPValue(LVLIndex))
                    XPRequiredData.Rows.Add(LVLIndex, XPValue(LVLIndex), Nothing)
                Else
                    XPRequiredData.Rows.Add(LVLIndex, XPValue(LVLIndex), Nothing)
                End If
            Else
                XPValue(LVLIndex) = ((XPValue(LVLIndex - 1) * PREVValue) + (LVLIndex * LVLValue) + CONValue)
                If XPValue(LVLIndex) <= Integer.MaxValue Then
                    XPValue(LVLIndex) = Convert.ToDecimal(XPValue(LVLIndex))
                    XPRequiredData.Rows.Add(LVLIndex, XPValue(LVLIndex), Nothing)
                Else
                    XPRequiredData.Rows.Add(LVLIndex, XPValue(LVLIndex), Nothing)
                End If
            End If
        Loop Until LVLIndex = FinishLVL
        Return 0
    End Function

    Private Sub LVLMIN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVLMIN.ValueChanged
        LVLMAX.Minimum = LVLMIN.Value + 1
        If LVLMAX.Value <= LVLMIN.Value Then
            LVLMAX.Value = LVLMIN.Value + 1
        End If
    End Sub

    Private Sub LVLMAX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVLMAX.ValueChanged
        LVLMAX.Minimum = LVLMIN.Value + 1
    End Sub

    Private Sub BTNCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCalculate.Click
        XPREQ()
    End Sub
#End Region

#Region "Randomize Stats"
    'Max HP =
    'Max MP =
#End Region

End Class
