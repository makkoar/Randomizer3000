namespace Randomizer5000.Enums;

/// <summary>Флаги генератор паролей</summary>
[Flags]
enum PGenFlag : byte
{
    None = 0,         // 0000
    /// <summary>Верхний регистр</summary>
    UpCase  = 1 << 0, // 0001
    /// <summary>Нижний регистр</summary>
    LowCase = 1 << 1, // 0010
    /// <summary>Цифры</summary>
    Numbers = 1 << 2, // 0100
    /// <summary>Специальные символы</summary>
    Symbols = 1 << 3  // 1000
}
