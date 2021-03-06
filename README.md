## Simple Factory Pattern Example ##

**技術：**
Asp.net MVC, ReportViewer   

**功能需求：**

財務報表預覽功能，讓User透過一個下拉選單選擇報表類別(共20種以上)，依照所選結果顯示報表。

> *實作方法：* 
> *因ReportViewer屬於Webform系列元件，因此必須於MVC頁面中崁入一個iframe 框住 webform頁面當做中介層，ReportViewer才能正常運行；即MVC主頁用Javascript依照下拉選單的值，改變iframe的url來觸發中介頁面運作ReportViewer。*

**發生問題：**

因每個報表格式都不一樣，會有二十多種不同 ReportModel 及 商業邏輯 ，在單一個中介程式中判斷各種報表類別將造成程式紊亂冗長

    
    //Middle Layer (webform page) 
	var reportType = request.form["type"]; 	
	switch(reportType){
		case "A":
			reportViewer.Path = "A.rdlc";
			reportViewer.DataSource = service.GetReportA();
		break;
		case "B":
			reportViewer.Path = "B.rdlc";
			reportViewer.DataSource = service.GetReportB();
		break;
		...
    }


Service也相對臃腫，維護不易


	//Service Layer
	public List<ReportA> GetReportA(){
		//code...
	}
	public List<ReportB> GetReportB(){
		//code...
	}
	...

若分成不同檔案處理，則會多產生20隻中介頁面、Service，程式碼雖然得以分散，但重複的程式碼過多，且面臨檔案管理問題。
**兩者都是個大災難！**

<br>
## 理想結果： ##

1. 中介檔案只有一隻，且只關注資料如何與ReportViewer元件互動，因此不應該再被更動(**對修改封閉原則**)；


	 		//Middle Layer (webform page) 
			var reportType = request.form["type"];
			var report = ReportFactory.Create(reportType);
			
			//about reportViewer
			reportViewer.Path = report.Path;
			reportViewer.DataSource = report.GetData();
1. 建立一個Factory及定義IReport Interface，在Factory處理報表類別代碼與回傳報表的對應規則，傳回實作IReport的報表物件(單純使用 Factory ，隨著報表增多Factory必須被擴充；搭配Reflection後，可不必再修改，同樣達到**修改封閉**效果)；
		
  		public static class ReportFactory{
			public static IReport Create(reportType){
				switch(reportType){
					case "A";
						return new ReportA();
					case "B";
						return new ReportB();
					....
				}
			}
		}

1. 將每種報表物件實作相同Interface，供Factory回傳結果。


		//Interface
		public Interface IReport{
			List<object> GetData();
		}

		//ReportA.cs
		public class ReportA:IReport{
		}

		//ReportB.cs
		public class ReportA:IReport{
		}

爾後，開發人員要建立一張新的報表，不用開新的頁面(且大半程式碼都是Copy Paste)，或者毫無章法的在一個檔案中不斷追加程式碼(當然，還必須跟命名原則繼續纏鬥)；用了Simple Factory Pattern的我們，只需要做兩件事情：

1. 建立自己的Report 類別，並且實作IReport；
1. 在Factory中擴充該報表的對應規則即可。(使用reflection new instance 時，此點可省略)



> 

> *以上描述重點概念, 程式碼僅為簡化版本*



<br>

## Sample Code ##

###Project: <a href="https://github.com/LezardYeh/Simple-Factory-Pattern/tree/master/Source">SimpleFactoryPattern</a>###

- **<a href="https://github.com/LezardYeh/Simple-Factory-Pattern/tree/master/Source/Before">Before</a>：**直接將所有程式碼寫於同一個檔案，僅用流程控制語法來整理程式碼；每次新增報表都必須對Index.aspx.cs, Service.cs做修改；
- **<a href="https://github.com/LezardYeh/Simple-Factory-Pattern/tree/master/Source/After">After</a>：**使用Factory Pattern及Reflection；新增報表只需要撰寫對應的 Report Class 即可。


> *不管用哪種做法，自行建立ReportModel及Rdlc都為必要工作*
>
> *11/16/2015 7:36:09 AM  PM*