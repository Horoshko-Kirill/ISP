
    internal class StudentBuilder : Builder
    {

        protected string name = String.Empty;
        protected Type.type type;
        protected DoWork? DoWork;

        public override Str Build()
        {
            Student student = new Student(name, type, DoWork);
            Console.WriteLine("А еще мы студенты");
            student.Learn();
            Console.WriteLine("-------------------");

            return student;
        }
    }

