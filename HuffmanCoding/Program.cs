
namespace HuffmanCoding
{
    internal class Program
    {
        static class HuffmanCoding
        {
            static PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();
            static Dictionary<char, String> codes = new Dictionary<char, String>();
            static Dictionary<String, char> characters = new Dictionary<String, char>();

            static Node root;
            public static void VariableLengthEncode(String text)
            {
                
                for(int i = 0; i < text.Length; i++)
                {
                    int occurences = 0;
                    for(int j = 0; j < text.Length; j++)
                    {
                        if(text[i] == text[j])
                        {
                            occurences++;
                        }
                    }
                    
                    if(occurences > 0 && !queue.UnorderedItems.Any(x => x.Element.character == text[i]))
                    {
                        queue.Enqueue(new Node(occurences, text[i]), occurences);
                    }
                }

                while(queue.Count > 1)
                {
                    var left = queue.Dequeue();
                    var right = queue.Dequeue();
                    var parent = new Node(left.frequency + right.frequency);
                    parent.left = left;
                    parent.right = right;
                    queue.Enqueue(parent, parent.frequency);                   

                }
                root = queue.Dequeue();
                Traverse(root, "");

            }

            public static String VariableLengthDecode(String code)
            {
                String currentCode = "";
                String text = "";
                for(int i = 0; i < code.Length ; i++)
                {
                    currentCode += code[i];
                    if (codes.ContainsValue(currentCode))
                    {
                        text += characters[currentCode];
                        currentCode = "";
                    }
                }
                return text;
            }

            public static void Traverse(Node node, String code)
            {
                if (node.left == null && node.right == null)
                {
                    codes.Add(node.character, code);
                    characters.Add(code, node.character);
                    return;
                }
                if (node.left != null)
                {
                    Traverse(node.left, code + "0");
                }
                if (node.right != null)
                {
                    Traverse(node.right, code + "1");
                }
            }

            public static void Write(String text)
            {
                for(int i = 0; i < text.Length; i++)
                {
                    Console.Write(codes[text[i]]);
                }
            }


        }
        
        static void Main(string[] args)
        {
            HuffmanCoding.VariableLengthEncode("alkjadsl;fjaas;dlfkjasdf;lkj");
            HuffmanCoding.Write("alkjadsl;fjaas;dlfkjasdf;lkj");
            Console.WriteLine();
            Console.WriteLine(HuffmanCoding.VariableLengthDecode("111101000110111100011101010001110111111011010100101001000110111011100001010101000110"));
        }
    }
}
