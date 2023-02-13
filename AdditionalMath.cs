public static class AdditionalMath
{
    static AdditionalMath() { }
   
    /// <summary>
    /// ������������� �������� ������ ��������� � ������.
    /// </summary>
    /// <param name="minFrom"> ����������� �������� ������� ���������.</param>
    /// <param name="maxFrom"> ������������ �������� ������� ���������. </param>
    /// <param name="minTo"> ����������� �������� ������� ���������. </param>
    /// <param name="maxTo"> ������������ �������� ������� ���������. </param>
    /// <param name="value"> ���������������� �������� ������� ���������. </param>
    /// <returns> ����������������� �������� ������� ��������� �� ������. </returns>
    public static float Lerp(float minFrom, float maxFrom, float minTo, float maxTo, float value)
    {
        return minTo + (value - minFrom) / (maxFrom - minFrom) * (maxTo - minTo);
    }
}
