using MaleeUtilities.SAP.Utils;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABAP_TEST
{
    public class DataContainer
    {
        public string PREQ_NO { get; set; }
        public string PR_TYPE { get; set; }
        public string CTRL_IND { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Note worth to read
            //https://archive.sap.com/discussions/thread/760060
            //Import = input parameter
            //Export = output parameter
            //Table = output tables
            //http://logosworld.com/docs/SAP/Connector/SAP%20Connector%20for%20Microsoft%20.NET%20%20NCo_30_ProgrammingGuide.pdf
            //https://www.sapnuts.com/courses/core-abap/modularization-in-abap/tables-function-modules.html
            /**
             Function modules can have the following interface parameters:

                Import parameters. These must be supplied with data when you call the function module, unless they are flagged as optional. You cannot change them in the function module.
                
                Export parameters. These pass data from the function module back to the calling program. Export parameters are always optional. You do not have to receive them in your program.
                
                Changing parameters. These must be supplied with data when you call the function module, unless they are flagged as optional. They can be changed in the function module. The changed values are then returned to the calling program.
                
                Tables parameters. You use these to pass internal tables. They are treated like CHANGING parameters. However, you can also pass internal tables with other parameters if you specify the parameter type appropriately.
                
                Calling Function Modules in ABAP
                
                To call a function module, use the CALL FUNCTION statement:
                
                CALL FUNCTION [EXPORTING f1 = a 1.... f n = a n] [IMPORTING f1 = a 1.... f n = a n] [CHANGING f1 = a 1.... f n = a n] [TABLES f1 = a 1.... f n = a n] [EXCEPTIONS e1 = r 1.... e n = r n [ERROR_MESSAGE = r E] [OTHERS = ro]].
                
                You can specify the name of the function module either as a literal or a variable. Each interface parameter is explicitly assigned to an actual parameter . You can assign a return value to each exception . The assignment always takes the form = . The equals sign is not an assignment operator in this context.
                
                After EXPORTING, you must supply all non-optional import parameters with values appropriate to their type. You can supply values to optional import parameters if you wish.
                
                After IMPORTING, you can receive the export parameters from the function module by assigning them to variables of the appropriate type.
                
                After CHANGING or TABLES, you must supply values to all of the non-optional changing or tables parameters. When the function module has finished running, the changed values are passed back to the actual parameters. You can supply values to optional changing or tables parameters if you wish.
                
                Check this link ..
                
                http://help.sap.com/saphelp_nw04/helpdata/en/9f/db98fc35c111d1829f0000e829fbfe/content.htm
             
             
             */

            /*
             * Example
             * static IRfcTable GetTableByRfcCall(string destName, int rowCount)
                 {
                 // get the destination
                 RfcDestination dest = RfcDestinationManager.GetDestination(destName);
                 // create a function object
                 IRfcFunction func = dest.Repository.CreateFunction("STFC_STRUCTURE");
                 //prepare input parameters
                 IRfcStructure impStruct = func.GetStructure("IMPORTSTRUCT");
                 impStruct.SetValue("RFCFLOAT", 12345.6789);
                 impStruct.SetValue("RFCCHAR1", "A");
                 impStruct.SetValue("RFCCHAR2", "AB");
                 impStruct.SetValue("RFCCHAR4", "NCO3");
                 impStruct.SetValue("RFCINT4", 12345);
                 impStruct.SetValue("RFCHEX3", new byte[] { 0x41, 0x42, 0x43 });
                 impStruct.SetValue("RFCDATE", DateTime.Today.ToString("yyyy-MM-dd"));
                 impStruct.SetValue("RFCDATA1", "Hello World");
                 // fill the table parameter
                 IRfcTable rfcTable = func.GetTable("RFCTABLE");
                 for (int i = 0; i < rowCount; i++)
                 {
                 // make a copy of impStruct
                 IRfcStructure row = (IRfcStructure)impStruct.Clone();
                 // make such changes to the fields of the cloned structure
                 impStruct.SetValue("RFCFLOAT", 12345.6789 + i);
                 row.SetValue("RFCINT1", i);
                 row.SetValue("RFCINT2", i * 2);
                 row.SetValue("RFCINT4", i * 4);
                 impStruct.SetValue("RFCTIME", DateTime.Now.ToString("T"));
                 row.SetValue("RFCDATA1", i.ToString() + row.GetString("RFCDATA1"));
                 rfcTable.Append(row);
                 }
                 // submit the RFC call
                 func.Invoke(dest);
                 // Return the table. The backend has added one more line to it.
                 rfcTable = func.GetTable("RFCTABLE");
                 return rfcTable;
                 }
             */
            #endregion

            DestinationRegister.RegistrationDestination(new SAPDestinationSetting
            {
                AppServerHost = "sapeccdr.malee.co.th",
                Client = "880",
                User = "itadm",
                Password = "It@20170707",
                SystemNumber = "00",
                SystemID = "EAP"
            });
            var des = RfcDestinationManager.GetDestination(DestinationRegister.Destination());


            #region get


            //IRfcFunction function = des.Repository.CreateFunction("ZRFC_GET_PR");
            ////function.SetValue
            //function.Invoke(des);
            //IRfcParameter firstParameter = function[0];
            //IRfcStructure BAPIRETURN = firstParameter.GetStructure();
            ////return เป็น Structure ที่ถูก defined ด้วยชื่อ BAPIRETURN และมี properties TYPE,CODE,MESSAGE,LOG_NO,LOG_MSG_NO,MESSAGE_V1,MESSAGE_V2,MESSAGE_V3,MESSAGE_V4
            //Console.WriteLine(String.Format("{0}:{1}","TYPE",BAPIRETURN.GetValue("TYPE").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "CODE", BAPIRETURN.GetValue("CODE").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MESSAGE", BAPIRETURN.GetValue("MESSAGE").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "LOG_NO", BAPIRETURN.GetValue("LOG_NO").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "LOG_MSG_NO", BAPIRETURN.GetValue("LOG_MSG_NO").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MESSAGE_V1", BAPIRETURN.GetValue("MESSAGE_V1").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MESSAGE_V2", BAPIRETURN.GetValue("MESSAGE_V2").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MESSAGE_V3", BAPIRETURN.GetValue("MESSAGE_V3").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MESSAGE_V4", BAPIRETURN.GetValue("MESSAGE_V4").ToString()));
            //
            ////structure = รุปร่างของ row
            //
            //IRfcParameter secondParameter = function[1];
            //IRfcTable IT_EBAN = secondParameter.GetTable();//return เป็น table
            //IRfcStructure ZSTR_EBAN = IT_EBAN[0];
            //
            //Console.WriteLine(String.Format("{0}:{1}", "BANFN", ZSTR_EBAN.GetValue("BANFN").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "BNFPO", ZSTR_EBAN.GetValue("BNFPO").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "LOEKZ", ZSTR_EBAN.GetValue("LOEKZ").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "KNTTP", ZSTR_EBAN.GetValue("KNTTP").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "PSTYP", ZSTR_EBAN.GetValue("PSTYP").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MATNR", ZSTR_EBAN.GetValue("MATNR").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "TXZ01", ZSTR_EBAN.GetValue("TXZ01").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MENGE", ZSTR_EBAN.GetValue("MENGE").ToString()));
            //Console.WriteLine(String.Format("{0}:{1}", "MEINS", ZSTR_EBAN.GetValue("MEINS").ToString()));
            //
            ////var table = function.GetStructure(0); // index 0 เหมือนเป็น list ของ ICollection<IRfcStructure>
            //var test = function.ContainerType;
            ////var structure = table.GetStructure("ZSTR_EBAN");


            #endregion

            #region set(import)


            /** //BAPI_PR_GETDETAIL 
             * 
             * EXPORT PRHEADER:STRUCTURE BAPIMEREQHEADER
             * 
             * IMPORT ACCOUNT_ASSIGNMENT:CHAR1 [optional:SPACE]
             * IMPORT DELIVERY_ADDRESS:CHAR1 [optional:SPACE]
             * IMPORT HEADER_TEXT:CHAR1 [optional:SPACE]
             * IMPORT ITEM_TEXT:CHAR1 [optional:SPACE]
             * IMPORT NUMBER:CHAR10
             * IMPORT SC_COMPONENTS:CHAR1 [optional:SPACE]
             * IMPORT SERIAL_NUMBERS:CHAR1 [optional:SPACE]
             * IMPORT SERVICES:CHAR1 [optional:SPACE]
             * IMPORT VERSION:CHAR1 [optional:SPACE]
             * 
             * TABLES ALLVERSIONS:STRUCTURE BAPIMEDCM_ALLVERSIONS
             * TABLES EXTENSIONOUT:STRUCTURE BAPIPAREX
             * TABLES PRACCOUNT:STRUCTURE BAPIMEREQACCOUNT ----> Account Assignment = 'X'
             * TABLES PRADDRDELIVERY:STRUCTURE BAPIMERQADDRDELIVERY
             * TABLES PRCOMPONENTS:STRUCTURE BAPIMEREQCOMPONENT
             * TABLES PRHEADERTEXT:STRUCTURE BAPIMEREQHEADTEXT
             * TABLES PRITEM:STRUCTURE BAPIMEREQITEM
             * TABLES PRITEMTEXT:STRUCTURE BAPIMEREQITEMTEXT
             * TABLES RETURN:STRUCTURE BAPIRET2
             * TABLES SERIALNUMBERS:STRUCTURE BAPIMEREQSERIALNO
             * TABLES SERVICEACCOUNT:STRUCTURE BAPI_SRV_ACC_DATA
             * TABLES SERVICECONTRACTLIMITS:STRUCTURE BAPI_SRV_CONTRACT_LIMITS
             * TABLES SERVICELIMIT:STRUCTURE BAPI_SRV_LIMIT_DATA
             * TABLES SERVICELINES:STRUCTURE BAPI_SRV_SERVICE_LINE
             * TABLES SERVICELONGTEXTS:STRUCTURE BAPI_SRV_LONGTEXTS
             * TABLES SERVICEOUTLINE:STRUCTURE BAPI_SRV_OUTLINE
             * */
            IRfcFunction function = des.Repository.CreateFunction("BAPI_PR_GETDETAIL");
            //prepare import structure
            //IRfcStructure impStruct = function.GetStructure("IMPORTNAME");


            function.SetValue("NUMBER", "1021019932");
            //function.SetValue("ITEM_TEXT", "X");
            function.Invoke(des);

            IRfcParameter export = function["PRHEADER"];
            IRfcStructure structure = export.GetStructure();
            Dictionary<string, Expression<Func<DataContainer, object>>> setting = new Dictionary<string, Expression<Func<DataContainer, object>>>
            {
                { "PREQ_NO", x=>x.PREQ_NO},
                { "PR_TYPE", x=>x.PR_TYPE},
                { "CTRL_IND", x=>x.CTRL_IND},
            };
            var output = structure.ToClass(setting);

            //var PREQ_NO = structure.GetValue("PREQ_NO");

            IRfcParameter returnTable = function["PRITEM"];
            var table1 = returnTable.GetTable();
            foreach (var record in table1)
            {
                Console.WriteLine(String.Format("{0}:{1}", record.GetInt("PREQ_ITEM"), record.GetValue("PREQ_ITEM").ToString()));
            }

            #endregion set
        }
    }
}
