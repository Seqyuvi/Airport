
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Airport.Tests
{

using System;
    using System.Collections.Generic;
    
public partial class FormOfPayments
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public FormOfPayments()
    {

        this.TicketsSelling = new HashSet<TicketsSelling>();

    }


    public int FormOfPaymentId { get; set; }

    public string TitleForm { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TicketsSelling> TicketsSelling { get; set; }

}

}
