using System;
using System.Data.SQLite;

namespace UnicomTicManageSystemApp.Data
{
    internal class DatabaseInitializer
    {
        public static void CreateTables()
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                 CREATE TABLE IF NOT EXISTS Users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        UserPassword TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );



                   CREATE TABLE IF NOT EXISTS Sections (
                        SectionId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SectionName TEXT NOT NULL
                    );


                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        SectionId INTEGER NOT NULL,
                        FOREIGN KEY (SectionId) REFERENCES Sections(SectionId)
                    );

                    CREATE TABLE IF NOT EXISTS Lectures (
                        LectureId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        City TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Staffs (
                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,                       
                        Email TEXT,
                        Phone TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Students (
                        StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        City TEXT NOT NULL,
                        SectionId INTEGER,
                        FOREIGN KEY (SectionId) REFERENCES Sections(SectionId)
                    );

                    CREATE TABLE IF NOT EXISTS Exams (
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        ExamDate TEXT NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
                    );

                    CREATE TABLE IF NOT EXISTS Marks (
                        MarkId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        ExamId INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        StaffId INTEGER NOT NULL,
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),
                        FOREIGN KEY (ExamId) REFERENCES Exams(ExamId),
                        FOREIGN KEY (StaffId) REFERENCES Staffs(StaffId)
                    );

                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Timetables (
                        TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SectionId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        LectureId INTEGER NOT NULL,
                        RoomId INTEGER NOT NULL,
                        Day TEXT NOT NULL,
                        Date TEXT NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        StaffId INTEGER,
                        FOREIGN KEY (StaffId) REFERENCES Staffs(StaffId),

                        FOREIGN KEY (SectionId) REFERENCES Sections(SectionId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),
                        FOREIGN KEY (LectureId) REFERENCES Lectures(LectureId),
                        FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
                    );

                    CREATE TABLE IF NOT EXISTS Student_Lecture (
                        StudentId INTEGER NOT NULL,
                        LectureId INTEGER NOT NULL,
                        PRIMARY KEY (StudentId, LectureId),
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (LectureId) REFERENCES Lectures(LectureId)
                    );

                    CREATE TABLE IF NOT EXISTS Student_Subject (
                        StudentId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        PRIMARY KEY (StudentId, SubjectId),
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
                    );

                    CREATE TABLE IF NOT EXISTS Subject_Lecture (
                        SubjectId INTEGER NOT NULL,
                        LectureId INTEGER NOT NULL,
                        PRIMARY KEY (SubjectId, LectureId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),
                        FOREIGN KEY (LectureId) REFERENCES Lectures(LectureId)
                    );

                    CREATE TABLE IF NOT EXISTS Lecture_Section (
                        LectureId INTEGER NOT NULL,
                        SectionId INTEGER NOT NULL,
                        PRIMARY KEY (LectureId, SectionId),
                        FOREIGN KEY (LectureId) REFERENCES Lectures(LectureId),
                        FOREIGN KEY (SectionId) REFERENCES Sections(SectionId)
                    );

                    CREATE TABLE IF NOT EXISTS StudentAttendance (
                        AttendanceId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER NOT NULL,
                        AttendanceDate TEXT NOT NULL,
                        Status TEXT NOT NULL, -- 'Present' or 'Absent'
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
                    );

                    CREATE TABLE IF NOT EXISTS LectureAttendance (
                        AttendanceId INTEGER PRIMARY KEY AUTOINCREMENT,
                        LectureId INTEGER NOT NULL,
                        AttendanceDate TEXT NOT NULL,
                        Status TEXT NOT NULL, -- 'Present' or 'Absent'
                        FOREIGN KEY (LectureId) REFERENCES Lectures(LectureId)
                    );

                    CREATE TABLE IF NOT EXISTS StaffAttendance (
                        AttendanceId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffId INTEGER NOT NULL,
                        AttendanceDate TEXT NOT NULL,
                        Status TEXT NOT NULL, -- 'Present' or 'Absent'
                        FOREIGN KEY (StaffId) REFERENCES Staffs(StaffId)
                    );
                ";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
