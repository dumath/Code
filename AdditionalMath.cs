public static class AdditionalMath
{
    static AdditionalMath() { }
   
    /// <summary>
    /// Интерполирует значение одного интервала в другой.
    /// </summary>
    /// <param name="minFrom"> Минимальное значение первого интервала.</param>
    /// <param name="maxFrom"> Максимальное значение второго интервала. </param>
    /// <param name="minTo"> Минимальное значение первого интервала. </param>
    /// <param name="maxTo"> Максимальное значение второго интервала. </param>
    /// <param name="value"> Интерполуриуемое значение первого интервала. </param>
    /// <returns> Интерполированное значение первого интервала во второй. </returns>
    public static float Lerp(float minFrom, float maxFrom, float minTo, float maxTo, float value)
    {
        return minTo + (value - minFrom) / (maxFrom - minFrom) * (maxTo - minTo);
    }
}
