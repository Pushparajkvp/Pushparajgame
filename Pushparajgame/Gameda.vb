Public Class Form1
    Private goodhp As Integer = 1000
    Private evilhp As Integer = 1000
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblgoodhp.Text = Val(goodhp)
        lblbadhp.Text = Val(evilhp)
        lblcurrentatks.Text = "Let The Battle Begin!"
        lblevilassign.Text = Val(3)
        lblgoodteach.Text = Val(5)
        lblevilpunish.Text = Val(3)
        lblgoodenjoy.Text = Val(3)
        lblevilsalary.Text = Val(2)
        lblgoodenjoy.Text = Val(2)
        lblgoodencourage.Text = Val(1)
        lblevilpunish.Text = Val(1)
        lblgoodstory.Text = Val(4)
        lblevilassign.Text = Val(5)
        lblevilscould.Text = Val(4)
        proggood.Increment(1000)
        pogevil.Increment(1000)
        turn = 1
        If turn Mod 2 = 1 Then
            lblturns.Text = "Superman's Turn"
        Else
            lblturns.Text = "Batman's Turn"
        End If
    End Sub
    Dim turn As Integer
    Dim hp As New Random

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If turn Mod 2 = 1 Then
            Dim rand1 As Integer
            Dim rand2 As Integer
            If chgoodstory.CheckState And chgoodpractical.CheckState = False Then
                lblgoodstory.Text = Val(check(Val(lblgoodstory.Text - 1), False, 40, 70, rand1))
                lblcurrentatks.Text = "Superman Has caused  " & rand1 & " Damage To Batman"
            ElseIf chgoodstory.CheckState And chgoodpractical.CheckState Then
                If Val(lblgoodstory.Text) And Val(lblgoodteach.Text) >= 0 Then
                    lblgoodteach.Text = Val(check(Val(lblgoodteach.Text - 1), False, 130, 170, rand1))
                    lblgoodstory.Text = Val(check(Val(lblgoodstory.Text - 1), False, 40, 70, rand2))
                    lblcurrentatks.Text = "The Superman caused  " & rand1 + rand2 & "Damage To Batman"
                Else
                    MessageBox.Show("The Special Power you can use is out of charge!", "Over", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf chgoodstory.CheckState = False And chgoodpractical.CheckState Then
                lblgoodteach.Text = Val(check(Val(lblgoodteach.Text - 1), False, 130, 170, rand1))
                lblcurrentatks.Text = "Superman Has caused  " & rand1 & "To Batman"
            ElseIf chgoodstory.CheckState = False And chgoodpractical.CheckState = False Then
                rand1 = hp.Next(20, 30)
                lblcurrentatks.Text = "The Superman has caused  " & rand1 & " Damage to Batman"
                If Damage(hp.Next(20, 30), False, "good") Then
                    MessageBox.Show("Oh No Batman Is Dead!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
            End If
            chgoodstory.CheckState = False
            chgoodpractical.CheckState = False
            turn += 1
            If turn Mod 2 = 1 Then
                lblturns.Text = "Superman's Turn"
            Else
                lblturns.Text = "Batman's Turn"
            End If
        Else
            MessageBox.Show("Its Not your turn Superman", "Invalid Turn", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If turn Mod 2 = 1 Then
            Dim rand1 As Integer
            Dim rand2 As Integer
            If chgoodencouragge.CheckState = False And chgoodenjoy.CheckState = False Then
                MessageBox.Show("You must select a Heal first ", "Select", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If chgoodencouragge.CheckState And chgoodenjoy.CheckState = False Then
                If Val(lblgoodencourage.Text) > 0 Then
                    lblgoodencourage.Text = Val(check(Val(lblgoodencourage.Text - 1), True, 70, 80, rand1))
                    If Val(lblgoodhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "The Superman Has Healed for   " & rand1 & " Damage"
                    End If
                Else
                    MessageBox.Show("You cannot use that heal because the charges are over ", "Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            ElseIf chgoodencouragge.CheckState And chgoodenjoy.CheckState Then
                If Val(lblgoodencourage.Text) And Val(lblgoodenjoy.Text) > 0 Then
                    lblgoodencourage.Text = Val(check(Val(lblgoodencourage.Text - 1), True, 70, 80, rand1))
                    lblgoodenjoy.Text = Val(check(Val(lblgoodenjoy.Text - 1), True, 50, 60, rand2))
                    If Val(lblgoodhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "The Superman Has Healed for  " & rand1 + rand2 & " Damage"
                    End If
                Else
                    MessageBox.Show("The Special Power you can use is out of charge!", "Over", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf chgoodencouragge.CheckState = False And chgoodenjoy.CheckState Then
                If Val(lblgoodenjoy.Text) > 0 Then
                    lblgoodenjoy.Text = Val(check(Val(lblgoodenjoy.Text - 1), True, 50, 60, rand1))
                    If Val(lblgoodhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "The Superman Has Healed for   " & rand1 & " Damage"
                    End If
                Else
                    MessageBox.Show("You cannot use that heal because the charges are over ", "Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            chgoodencouragge.CheckState = False
            chgoodenjoy.CheckState = False
            turn += 1
            If turn Mod 2 = 1 Then
                lblturns.Text = "Superman's Turn"
            Else
                lblturns.Text = "Batman's Turn"
            End If
        Else
            MessageBox.Show("Its Not your Turn Superman", "Invalid Turn", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If turn Mod 2 = 0 Then
            Dim rand1 As Integer
            Dim rand2 As Integer
            If chbadass.CheckState And chbadscould.CheckState = False Then
                lblevilassign.Text = Val(checkevil(Val(lblevilassign.Text - 1), False, 150, 200, rand1))
                lblcurrentatks.Text = "Batman Has caused  " & rand1 & " Damage To Superman"
            ElseIf chbadass.CheckState And chbadscould.CheckState Then
                If Val(lblevilassign.Text) And Val(lblevilscould.Text) >= 0 Then
                    lblevilassign.Text = Val(checkevil(Val(lblevilassign.Text - 1), False, 150, 200, rand1))
                    lblevilscould.Text = Val(checkevil(Val(lblevilscould.Text - 1), False, 50, 80, rand2))
                    lblcurrentatks.Text = "Batman Has caused  " & rand1 + rand2 & " Damage To Superman"
                Else
                    MessageBox.Show("The Special Power you can use is out of charge!", "Over", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf chbadass.CheckState = False And chbadscould.CheckState Then
                lblevilscould.Text = Val(checkevil(Val(lblevilscould.Text - 1), False, 50, 80, rand1))
                lblcurrentatks.Text = "Batman Has caused  " & rand1 & " To Superman"
            ElseIf chbadass.CheckState = False And chbadscould.CheckState = False Then
                rand1 = hp.Next(20, 30)
                lblcurrentatks.Text = "Batman Has caused  " & rand1 & " To Superman"
                If Damage(rand1, False) Then
                    MessageBox.Show("Oh No Superman Is Dead!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
            End If
            chbadass.CheckState = False
            chbadscould.CheckState = False
            turn += 1
            If turn Mod 2 = 1 Then
                lblturns.Text = "Superman's Turn"
            Else
                lblturns.Text = "Batman's Turn"
            End If
        Else
            MessageBox.Show("Its Not your turn Batman", "Invalid Turn", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If turn Mod 2 = 0 Then
            Dim rand1 As Integer
            Dim rand2 As Integer
            If chevilpunish.CheckState = False And chevilslalary.CheckState = False Then
                MessageBox.Show("You must select a Heal first ", "Select", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If chevilpunish.CheckState And chevilslalary.CheckState = False Then
                If Val(lblevilpunish.Text) > 0 Then
                    lblevilpunish.Text = Val(checkevil(Val(lblevilpunish.Text - 1), True, 50, 60, rand1))
                    If Val(lblbadhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "Batman Has Healed for   " & rand1 & " Damage"
                    End If
                Else
                    MessageBox.Show("You cannot use that heal because the charges are over ", "Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            ElseIf chevilpunish.CheckState And chevilslalary.CheckState Then
                If Val(lblevilpunish.Text) And Val(lblevilsalary.Text) >= 0 Then
                    lblevilpunish.Text = Val(checkevil(Val(lblevilpunish.Text - 1), True, 50, 60, rand1))
                    lblevilsalary.Text = Val(checkevil(Val(lblevilsalary.Text - 1), True, 30, 50, rand2))
                    If Val(lblbadhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "Batman Has Healed for  " & rand1 + rand2 & " Damage"
                    End If

                Else
                    MessageBox.Show("The Special Power you can use is out of charge!", "Over", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf chevilpunish.CheckState = False And chevilslalary.CheckState Then
                If Val(lblevilsalary.Text) > 0 Then
                    lblevilsalary.Text = Val(checkevil(Val(lblevilsalary.Text - 1), True, 30, 50, rand1))
                    If Val(lblbadhp.Text) > 1000 Then
                        Exit Sub
                    Else
                        lblcurrentatks.Text = "Batman Has Healed for   " & rand1 & " Damage"
                    End If
                Else
                    MessageBox.Show("You cannot use that heal because the charges are over ", "Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            chevilpunish.CheckState = False
            chevilslalary.CheckState = False
            turn += 1
            If turn Mod 2 = 1 Then
                lblturns.Text = "Superman's Turn"
            Else
                lblturns.Text = "Batman's Turn"
            End If
        Else
            MessageBox.Show("Its Not your Turn Batman", "Invalid Turn", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Function checkevil(ByVal string1 As Integer, ByVal heal As Boolean, ByVal num1 As Integer, ByVal num2 As Integer, ByRef rand As Integer) As Integer
        If heal = False Then
            If Val(string1 >= 0) Then
                rand = hp.Next(num1, num2)
                If Damage(rand, False) Then
                    MessageBox.Show("Oh No Superman Is Dead!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
            Else
                MessageBox.Show("You cant use that because you are out of That specific attack", "Cant Use it", MessageBoxButtons.OK, MessageBoxIcon.Information)
                string1 = Val(0)
            End If
            Return string1
        Else
            If Val(string1 >= 0) Then
                rand = hp.Next(num1, num2)
                If Damage(rand, True, "heal") = 2 Then
                    string1 += 1
                End If
            Else
                MessageBox.Show("You cant use that because you are out of That specific Heal", "Cant Use it", MessageBoxButtons.OK, MessageBoxIcon.Information)
                string1 = Val(0)
            End If
            Return string1
        End If

    End Function
    Private Function check(ByVal string1 As Integer, ByVal heal As Boolean, ByVal num1 As Integer, ByVal num2 As Integer, ByRef rand As Integer) As Integer
        If heal = False Then
            If Val(string1 >= 0) Then
                rand = hp.Next(num1, num2)
                If Damage(rand, False, "good") Then
                    MessageBox.Show("Oh No Batman Is Dead!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
            Else
                MessageBox.Show("You cant use that because you are out of That specific attack", "Cant Use it", MessageBoxButtons.OK, MessageBoxIcon.Information)
                string1 = Val(0)
            End If
            Return string1
        Else
            If Val(string1 >= 0) Then
                rand = hp.Next(num1, num2)
                If Damage(rand, True) = 2 Then
                    string1 = string1 + 1
                End If
            Else
                MessageBox.Show("You cant use that because you are out of That specific attack", "Cant Use it", MessageBoxButtons.OK, MessageBoxIcon.Information)
                string1 = Val(0)
            End If
            Return string1
        End If
    End Function
    Private Function Damage(ByVal dmg As Integer, ByVal heal As Boolean, Optional ByVal good As String = "bad") As Integer
        If heal = False Then
            If good = "bad" Then
                lblgoodhp.Text = Val(lblgoodhp.Text - dmg)
                proggood.Increment(-(dmg) / 10)
                If Val(lblgoodhp.Text) <= 0 Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                lblbadhp.Text = Val(lblbadhp.Text - dmg)
                pogevil.Increment(-(dmg) / 10)
                If Val(lblbadhp.Text) <= 0 Then
                    Return 1
                Else
                    Return 0
                End If
            End If
        Else
            If good = "bad" Then
                lblgoodhp.Text = Val(lblgoodhp.Text + dmg)
                If Val(lblgoodhp.Text) > 1000 Then
                    MessageBox.Show(" You cannot Heal above 1000 dont waste it !", "Over Heal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lblgoodhp.Text = Val(lblgoodhp.Text - dmg)
                    Return 2
                    Exit Function
                End If
                proggood.Increment((dmg) / 10)
                If Val(lblgoodhp.Text) <= 0 Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                lblbadhp.Text = Val(lblbadhp.Text + dmg)
                If Val(lblbadhp.Text) > 1000 Then
                    MessageBox.Show(" You cannot Heal above 1000 dont waste it !", "Over Heal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lblbadhp.Text = Val(lblbadhp.Text - dmg)
                    Return 2
                    Exit Function
                End If
                pogevil.Increment((dmg) / 10)
                If Val(lblbadhp.Text) <= 0 Then
                    Return 1
                Else
                    Return 0
                End If
            End If
        End If
    End Function


End Class

