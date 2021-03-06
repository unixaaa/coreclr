using System;
using System.Collections.Generic;
using System.Collections;
/// <summary>
///GetEnumerator 
/// </summary>
public class ListIEnumerableGetEnumerator2
{
    public static int Main()
    {
        ListIEnumerableGetEnumerator2 ListIEnumerableGetEnumerator2 = new ListIEnumerableGetEnumerator2();
        TestLibrary.TestFramework.BeginTestCase("ListIEnumerableGetEnumerator2");
        if (ListIEnumerableGetEnumerator2.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling GetEnumerator method of IEnumerable,T is Value type.");
        try
        {
            List<int> myList = new List<int>();
            int count = 10;
            int[] expectValue = new int[10];

            for (int i = 1; i <= count; i++)
            {
                myList.Add(i * count);
                expectValue[i - 1] = i * count;
            }
            IEnumerator returnValue = ((IEnumerable)myList).GetEnumerator();
            int j = 0;
            for (IEnumerator itr = returnValue; itr.MoveNext(); )
            {
                int current = (int)itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("001.1." + j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: Calling GetEnumerator method of IEnumerable,T is reference type.");
        try
        {
            List<string> myList = new List<string>();
            int count = 10;
            string[] expectValue = new string[10];
            string element = string.Empty;
            for (int i = 1; i <= count; i++)
            {
                element = i.ToString();
                myList.Add(element);
                expectValue[i - 1] = element;
            }
            IEnumerator returnValue = ((IEnumerable)myList).GetEnumerator();
            int j = 0;
            for (IEnumerator itr = returnValue; itr.MoveNext(); )
            {
                string current = (string)itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("002.1." + j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

}

