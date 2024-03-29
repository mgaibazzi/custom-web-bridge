﻿using customwebbridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static customwebbridge.BaseItem;
using static System.Net.Mime.MediaTypeNames;

namespace customwebbridge
{
    public class Barcode : BaseItem

    {

        //commmon variables
        int width;
        int height;
        string data = "";



        //default constructor
        public Barcode(ItemType pType) : base(pType)
        {
            pType = ItemType.none;
            Width = 276;
            Height = 276;
            Data = "765";
        }
        //parameterized constructor
        public Barcode(ItemType pType, int width, int height, string data) : base(pType)
        {

            pType = ItemType.none;

            this.width = width;

            this.height = height;

            this.data = data;

        }

        //getter and setter
        public int Width { get => width; set => width = value; }
        public string Data { get => data; set => data = value; }
        public int Height { get => height; set => height = value; }
    }

}
public class Barcode2D : Barcode
{   
    //Barcode2d ECL enum
    public enum ErrorCorrectionLevel
    {
        level_0,
        level_1,
        level_2,
        level_3,
        level_4,
        level_5,
        level_6,
        level_7,
        level_8,
        level_l,
        level_m,
        level_q,
        level_h,
        Default                  
    }
    //Barcode2d Type enum
    public enum Type
    {
        pdf417_standard,
        pdf417_truncated,
        qrcode_model_1,
        qrcode_model_2,
        qrcode_micro,
        maxicode_mode_2,
        maxicode_mode_3,
        maxicode_mode_4,
        maxicode_mode_5,
        maxicode_mode_6,
        gs1_databar_stacked,
        gs1_databar_stacked_omnidirectional,
        gs1_databar_expanded_stacked,
        azteccode_fullrange,
        azteccode_compact,
        datamatrix_square,
        datamatrix_rectangle_8,
        datamatrix_rectangle_12,
        datamatrix_rectangle_16,
    }

    int errorCorrectionLevelAztecCode;
    int s_size;
    private ErrorCorrectionLevel errorCorrectionLevel;
    private Type typeQRCode;



    //Barcode2d Default constructor
    public Barcode2D(int width, int height, string data) : base(ItemType.qrcode, width, height, data)//default constructor

    {
        TypeQRCode = Type.pdf417_standard;
        Width = 105;
        Height = 100;
        Data = "2345678";
        ErrorCorrectionLevel1 = ErrorCorrectionLevel.Default;
        ErrorCorrectionLevelAztecCode = 23;
        S_size = 1220;

    }
    //Barcode2d parameterized constructor
    public Barcode2D(int width, int height, string data, ErrorCorrectionLevel ecl, int errorCorrectionLevelAztecCode, int s_size, Type type) : base(ItemType.qrcode, width, height, data)//main constructor

    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
        this.ErrorCorrectionLevel1 = ecl;
        this.ErrorCorrectionLevelAztecCode = errorCorrectionLevelAztecCode;
        this.TypeQRCode = type;
        this.S_size = s_size;

    }



    //getter & setter

    public int ErrorCorrectionLevelAztecCode
    {
        get { return errorCorrectionLevelAztecCode; }
        set
        {
            if (value < 5 && value > 95)
            {
                throw new Exception("Valore non corretto");
            }
            else errorCorrectionLevelAztecCode = value;

        }
    }
    public int S_size
    {
        get { return s_size; }
        set
        {
            if (value < 0 && value > 2400)
            {
                throw new Exception("Valore non corretto");
            }
            else s_size = value;

        }
    }
    public ErrorCorrectionLevel ErrorCorrectionLevel1 { get => errorCorrectionLevel; set => errorCorrectionLevel = value; }
    public Type TypeQRCode { get => typeQRCode; set => typeQRCode = value; }

    //Barcode2d class ToString
    public override string ToString()
    {
        string str = "Data: " + Data + "\n"
                        + "Size: " + S_size + "\n"
                        + "Width: " + Width.ToString() + "\n"
                        + "Height: " + Height.ToString() + "\n"
                        + "ErrorCorrectionLevel: " + ErrorCorrectionLevel1 + "\n"
                        + "TypeQRCode: " + TypeQRCode + "\n"
                        + "ErrorCorrectionLevelAztecCode: " + ErrorCorrectionLevelAztecCode + "\n"
                        + base.ToString();
        return str;
    }
}

public class Barcode1D : Barcode
{
    //Barcode1d Type enum
    public enum Type
    {
        code39,
        upc_a,
        upc_e,
        ean13,
        jan13,
        ean8,
        jan8,
        itf,
        codabar,
        code93,
        code128,
        gs1_128,
        gs1_databar_omnidirectional,
        gs1_databar_truncated,
        gs1_databar_limited,
        gs1_databar_expanded
    }
    //barcode1d Human Readable Interface enum
    public enum HRI
    {
        none,
        above,
        below,
        both
    }
//Barcode1d  FOntStyle enum
    public enum FontStyle
    {
        font_a,
        font_b,
        font_c,
        font_d,
        font_e,
        special_a,
        special_b
    }


    FontStyle Font;
    HRI Hri;
    Type barcodeType;

//barcode1d default constructor
    public Barcode1D(int width, int height, string data) : base(ItemType.barcode, width, height, data)//default constructor
    {
        barcodeType = Type.code39;
        Width = 2;
        Height = 32;
        Data = "12345";
        Hri1 = HRI.none;
        Font1 = FontStyle.font_a;
    }
    //Barcode1d parameterized constructor
    public Barcode1D(int width, int height, string data, HRI hri, FontStyle font, Type type) : base(ItemType.barcode, width, height, data)//main constructor
    {
        barcodeType = type;
        this.Width = width;
        this.Height = height;
        this.Data = data;
        this.Hri1 = hri;
        this.Font1 = font;
    }

    //getter & setter
    public FontStyle Font1 { get => Font; set => Font = value; }
    public HRI Hri1 { get => Hri; set => Hri = value; }

    public Type BarcodeType { get => barcodeType; set => barcodeType = value; }


    //Barcode1d class ToString
    public override string ToString()
    {
        string str =    "Data: " + Data + "\n"
                        +"Hri: " + Hri1  + "\n"
                        +"Width: " + Width.ToString() + "\n"
                        +"Height: " + Height.ToString() + "\n"
                        +"Font: " + Font.ToString() + "\n"
                        +"BarcodeType: " + BarcodeType.ToString() + "\n"
                        +base.ToString();
        return str;
    }
}
