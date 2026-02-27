using System;

NumeroNatural numero = new NumeroNatural(12345);

Console.WriteLine("antes " + numero.GetValor());

numero.InsertarDigito(9, 2);

Console.WriteLine("despues " + numero.GetValor());
Console.WriteLine("ordenado" + numero.ordenar())

class NumeroNatural
{   
    private uint valor;

    public NumeroNatural(uint v)
    {
        valor = v;
    }

    public uint GetValor(){ return valor; }

    public bool Esprimo()
    {
        if(valor <=1) return false; 
        for (uint i = 2; i * i <= valor; i++)
        {
            if (valor % i == 0)
                return false;
        }
        return true;
    }

    public int cntdigitos()
    {
        int x =(int)Math.Log10(valor);
        return x+1;
    }

  
    public void ponernumero(uint digito, uint posicion)
    {
        uint potencia = (uint)Math.Pow(10, posicion);

        uint derecha = valor % potencia;
        uint izquierda = valor / potencia;

        valor = (izquierda * 10 + digito) * potencia + derecha;
    }
    public int cntdigitos()
    {
        int x =(int)Math.Log10(valor);
        return x+1;
    }

    public void ordenar()
    {
        uint numero = valor;

        int c0=0,c1=0,c2=0,c3=0,c4=0,c5=0,c6=0,c7=0,c8=0,c9=0;

        while(numero > 0)
        {
            uint digi = numero % 10;

            switch(digi)
            {
                case 0: c0++; break;
                case 1: c1++; break;
                case 2: c2++; break;
                case 3: c3++; break;
                case 4: c4++; break;
                case 5: c5++; break;
                case 6: c6++; break;
                case 7: c7++; break;
                case 8: c8++; break;
                case 9: c9++; break;
            }

            numero /= 10;
        }

        uint resultado = 0;

        void Agregar(int cantidad, uint digi)
        {
            for(int i = 0; i < cantidad; i++)
                resultado = resultado * 10 + digi;
        }

        Agregar(c0,0);
        Agregar(c1,1);
        Agregar(c2,2);
        Agregar(c3,3);
        Agregar(c4,4);
        Agregar(c5,5);
        Agregar(c6,6);
        Agregar(c7,7);
        Agregar(c8,8);
        Agregar(c9,9);

        valor = resultado;
    }

    public string Conv_literal()
    {
        if (valor == 0) return "cero";

        string[] unidades = {
            "", "uno", "dos", "tres", "cuatro",
            "cinco", "seis", "siete", "ocho", "nueve"
        };

        string[] especiales = {
            "diez", "once", "doce", "trece", "catorce",
            "quince", "dieciseis", "diecisiete",
            "dieciocho", "diecinueve"
        };

        string[] decenas = {
            "", "", "veinte", "treinta", "cuarenta",
            "cincuenta", "sesenta", "setenta",
            "ochenta", "noventa"
        };

        string[] centenas = {
            "", "ciento", "doscientos", "trescientos",
            "cuatrocientos", "quinientos", "seiscientos",
            "setecientos", "ochocientos", "novecientos"
        };

        if (valor == 100) return "cien";

        uint numero = valor;

        uint c = numero / 100;
        uint d = (numero % 100) / 10;
        uint u = numero % 10;

        string literal = "";

        literal += centenas[c];
        if (c > 0) literal += " ";

        uint ultimosDos = numero % 100;

        if (ultimosDos >= 10 && ultimosDos <= 19)
        {
            literal += especiales[ultimosDos - 10];
            return literal.Trim();
        }

        if (d == 2 && u != 0)
        {
            literal += "veinti" + unidades[u];
            return literal.Trim();
        }

        literal += decenas[d];

        if (d >= 3 && u != 0)
            literal += " y ";

        if (!(d == 2 && u != 0))
            literal += unidades[u];

        return literal.Trim();
    }
}