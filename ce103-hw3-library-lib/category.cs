using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_lib
{
    public class category
    {
       
       
        public const int CATEGORY_MAX_COUNT = 20;
        public const int CATEGORY_NAME_MAX_LENGTH = 20;

        public const int CATEGORY_DATA_BLOCK_SIZE = (CATEGORY_MAX_COUNT * CATEGORY_NAME_MAX_LENGTH);

        private List<string> _categories;
        public List<string> Categories { get { return _categories; } set { _categories = value; } }

        public category()
        {
            _categories = new List<string>();
        }
        public static byte[] BookToByteArrayBlock(category categories)
        {
            int index = 0;

            byte[] dataBuffer = new byte[CATEGORY_DATA_BLOCK_SIZE];

            #region copy book categories
            byte[] categoryBytes = ConversionUtility.StringListToByteArray(categories.Categories,
                                                                            category.CATEGORY_MAX_COUNT,
                                                                            category.CATEGORY_NAME_MAX_LENGTH);
            Array.Copy(categoryBytes, 0, dataBuffer, index, categoryBytes.Length);
            index += categoryBytes.Length; //Here we can use also Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH
            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }



        public static category ByteArrayBlockToBook(byte[] byteArray)
        {

            category catego = new category();

            if (byteArray.Length != CATEGORY_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            #region copy book categories
            byte[] categoryBytes = new byte[category.CATEGORY_MAX_COUNT * category.CATEGORY_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, categoryBytes, 0, categoryBytes.Length);

            catego.Categories = ConversionUtility.ByteArrayToStringList(categoryBytes,
                                                                            category.CATEGORY_MAX_COUNT,
                                                                            category.CATEGORY_NAME_MAX_LENGTH);

            index += categoryBytes.Length;
            #endregion

            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            else
            {
                return catego;
            }

        }
    }
}
            
