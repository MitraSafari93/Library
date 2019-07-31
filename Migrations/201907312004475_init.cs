namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookTbls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        translator = c.String(),
                        Available = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BorrowerTbls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDMember = c.Int(nullable: false),
                        IDBook = c.Int(nullable: false),
                        ReciveDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        DueDate = c.DateTime(nullable: false),
                        BookTbl_ID = c.Int(),
                        MembersTbl_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookTbls", t => t.BookTbl_ID)
                .ForeignKey("dbo.MembersTbls", t => t.MembersTbl_ID)
                .Index(t => t.BookTbl_ID)
                .Index(t => t.MembersTbl_ID);
            
            CreateTable(
                "dbo.MembersTbls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Int(),
                        JoinDate = c.DateTime(),
                        ExpiryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowerTbls", "MembersTbl_ID", "dbo.MembersTbls");
            DropForeignKey("dbo.BorrowerTbls", "BookTbl_ID", "dbo.BookTbls");
            DropIndex("dbo.BorrowerTbls", new[] { "MembersTbl_ID" });
            DropIndex("dbo.BorrowerTbls", new[] { "BookTbl_ID" });
            DropTable("dbo.MembersTbls");
            DropTable("dbo.BorrowerTbls");
            DropTable("dbo.BookTbls");
        }
    }
}
