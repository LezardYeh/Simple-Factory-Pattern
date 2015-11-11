## Simple Factory Pattern 實作案例 ##

**技術：**
Asp.net MVC, ReportViewer

**功能需求：**

財務報表預覽功能，讓User透過一個下拉選單選擇報表類別(共20種以上)，依照所選結果顯示報表。

**實作方法：**

因ReportViewer屬於Webform系列元件，因此必須於MVC頁面中崁入一個iframe 框住 webform頁面當做中介層，ReportViewer才能正常運行；即MVC主頁用Javascript依照下拉選單的值，改變iframe的url來觸發中介頁面運作ReportViewer。

**發生問題：**

因每個報表格式都不一樣，會有二十多種不同 ReportModel 及 商業邏輯 ，在單一個中介程式中判斷各種報表類別將造成程式紊亂冗長

    
    //Middle Layer (webform page) 
	var reportType = request.form["type"]; 	
	switch(reportType){
		case "A":
			service.getReportA();
		break;
		case "B":
			service.getReportA();
		break;
		...
    }


Service也相對臃腫，維護不易


	//Service Layer
	public ReportA(){
		//code...
	}
	public ReportB(){
		//code...
	}
	...

若分成不同檔案處理，則會多產生20隻中介頁面、Service，程式碼雖然得以分散，但重複的程式碼過多，且面臨檔案管理問題。
**兩者都是個大災難！**




## 理想結果： ##

1. 中介檔案只有一隻，且只關注資料如何與ReportViewer元件互動，因此不應該再被更動(對修改封閉原則)；


	 		//Middle Layer (webform page) 
			var reportType = request.form["type"];
			var report = ReportFactory.create(reportType);
			
			//about reportViewer
			reportViewer.Path = report.Path;
			reportViewer.DataSource = report.getData();
1. 建立一個Factory，專門處理報表類別代碼與結果的對應關係，並協助主程式取得正確的報表(以現階段的設計 Factory 隨著報表增多必須被擴充)；
		
  		public class Factory{
			public IReport create(reportType){
				switch(reportType){
					case "A";
						return new ReportA();
					break;
					case "B";
						return new ReportB();
					break;
					....
				}
			}
		}

1. 將每種報表物件實作相同Interface，供Factory回傳結果。


		//ReportA.cs
		public class ReportA:IReport{
		}

		//ReportB.cs
		public class ReportA:IReport{
		}

爾後，開發人員要建立一張新的報表，不用開新的頁面(且大半程式碼都是Copy Paste)，或者毫無章法的在一個檔案中不斷追加程式碼(當然，還必須跟命名原則繼續纏鬥)；因為此時，我們只需要做兩件事情：

1. 建立自己的Report 類別，並且實作IReport；
1. 在Factory中擴充該報表的對應規則即可。



> *以上僅描述重點概念，部分RDLC等實作細節不在討論之中*


> 11/11/2015 9:52:37 PM 