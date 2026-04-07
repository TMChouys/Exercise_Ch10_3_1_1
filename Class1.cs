using System;

interface IArea
{ // IArea介面
    double Area(); // 介面方法
}
interface IInfo
{ // IInfo介面
    string Info(); // 介面方法
}
class Rectangle : IArea, IInfo
{//類別實作IArea和IInfo介面
    public int Height;
    public int Width;
    public Rectangle(int h, int w)
    {
        Height = h;
        Width = w;
    }
    public double Area()
    { // 實作介面方法
        return (Height * Width);
    }
    public string Info()
    {
        return "長方形的長：" + Height + "\n" +
               "長方形的寬：" + Width;
    }
}

