namespace OOPEksamen
{
    class StregsystemController
    {
        Stregsystem Stregsystem { get; set; }
        IStregsystemUI StregsystemUI { get; set; }
        
        public StregsystemController(Stregsystem stregsystem, IStregsystemUI stregsystemUI)
        {
            Stregsystem = stregsystem;
            StregsystemUI = stregsystemUI;
        }


    }

 }

