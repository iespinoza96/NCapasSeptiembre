﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.MateriaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MateriaService.IMateria")]
    public interface IMateria {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Add", ReplyAction="http://tempuri.org/IMateria/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Plantel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Semestre))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Grupo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Materia))]
        ML.Result Add(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Add", ReplyAction="http://tempuri.org/IMateria/AddResponse")]
        System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Update", ReplyAction="http://tempuri.org/IMateria/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Plantel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Semestre))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Grupo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Materia))]
        ML.Result Update(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Update", ReplyAction="http://tempuri.org/IMateria/UpdateResponse")]
        System.Threading.Tasks.Task<ML.Result> UpdateAsync(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/GetAll", ReplyAction="http://tempuri.org/IMateria/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Materia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Grupo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Plantel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Semestre))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        ML.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/GetAll", ReplyAction="http://tempuri.org/IMateria/GetAllResponse")]
        System.Threading.Tasks.Task<ML.Result> GetAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMateriaChannel : PL_MVC.MateriaService.IMateria, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MateriaClient : System.ServiceModel.ClientBase<PL_MVC.MateriaService.IMateria>, PL_MVC.MateriaService.IMateria {
        
        public MateriaClient() {
        }
        
        public MateriaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MateriaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MateriaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MateriaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ML.Result Add(ML.Materia materia) {
            return base.Channel.Add(materia);
        }
        
        public System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Materia materia) {
            return base.Channel.AddAsync(materia);
        }
        
        public ML.Result Update(ML.Materia materia) {
            return base.Channel.Update(materia);
        }
        
        public System.Threading.Tasks.Task<ML.Result> UpdateAsync(ML.Materia materia) {
            return base.Channel.UpdateAsync(materia);
        }
        
        public ML.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ML.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
    }
}
