using System.Collections.Generic;
using System.Windows.Controls;
using Closer.array;
using Closer.util;

namespace Closer.page;

public partial class HistoryPage : Page
{
    private static HistoryPage _historyPage;

    public static HistoryPage getInstance()
    {
        if (_historyPage == null) _historyPage = new HistoryPage();
        return _historyPage;
    }

    public HistoryPage()
    {
        InitializeComponent();
        initData();
    }

    private void ListOnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void initData()
    {
        List<MessageArray> historyArrays = new HistoryUtil().getHistory();
        foreach (var historyArray in historyArrays)
        {
            historyList.Items.Add(historyArray);
        }
    }

    public void addHistory(MessageArray messageArray)
    {
        historyList.Items.Add(messageArray);
    }
}