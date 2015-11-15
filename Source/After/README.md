
**Index.aspx / Index.aspx.cs:**

主程式，定義ReportViewer元件，將ReportType值傳入Factory中產生報表物件



**Report:**

- **Interface**:定義報表類別的抽象方法及屬性(IReport)
- **ReportA.cs / ReportB.cs:**報表物件(實作IReport)
- **ReportFactory.cs:**工廠方法主程式(回傳實作IReport的實體)
- **Model:**各報表資料格式的ViewModel
- **Rdlc:**各報表使用的Rdlc