using System;
using System.Collections.Generic;
using System.Text;

namespace LCD
{
    public static class LCDConverter
    {
        private static Dictionary<char, char[,]> LCDdigits = new Dictionary<char, char[,]>
        {
            {
                '0', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '|', '.', '|'
                    },
                    {
                        '|', '_', '|'
                    }
                }
            },
            {
                '1', new char[3,3]
                {
                    {
                        '.','.','.'
                    },
                    {
                        '.', '.', '|'
                    },
                    {
                        '.', '.', '|'
                    }
                }
            },
            {
                '2', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '.', '_', '|'
                    },
                    {
                        '|', '_', '.'
                    }
                }
            },
            {
                '3', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '.', '_', '|'
                    },
                    {
                        '.', '_', '|'
                    }
                }
            },
            {
                '4', new char[3,3]
                {
                    {
                        '.','.','.'
                    },
                    {
                        '|', '_', '|'
                    },
                    {
                        '.', '.', '|'
                    }
                }
            },
            {
                '5', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '|', '_', '.'
                    },
                    {
                        '.', '_', '|'
                    }
                }
            },
            {
                '6', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '|', '_', '.'
                    },
                    {
                        '|', '_', '|'
                    }
                }
            },
            {
                '7', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '.', '.', '|'
                    },
                    {
                        '.', '.', '|'
                    }
                }
            },
            {
                '8', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '|', '_', '|'
                    },
                    {
                        '|', '_', '|'
                    }
                }
            },
            {
                '9', new char[3,3]
                {
                    {
                        '.','_','.'
                    },
                    {
                        '|', '_', '|'
                    },
                    {
                        '.', '.', '|'
                    }
                }
            }
        };

        public static string Convert(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number));
            }

            var stringNumber = number.ToString();
            var result = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                foreach (var digit in stringNumber)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var lcd = LCDdigits[digit];
                        result.Append(lcd[i, j]);
                    }
                }
                result.Append('\n');
            }

            return result.ToString();
        }
    }
}
