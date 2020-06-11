using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASCIIGameJam {

    class Program {

        // To lock the window size
        [DllImport("user32.dll")] public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")] private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll")] private static extern IntPtr GetConsoleWindow();

        // To set to UTF-8
        [DllImport("kernel32.dll", SetLastError = true)] private static extern bool SetConsoleOutputCP(uint wCodePageID);
        [DllImport("kernel32.dll", SetLastError = true)] private static extern bool SetConsoleCP(uint wCodePageID);

        public static string[] pixelArt = {
            "      00           ","     0  0          ","     0  0          ","      00           ","             000   ",
            "   0  00     0  00 ","00   0  0 0 00    0"," 0   0  0    0  00 ","     0000    000   ","                   ",
            "     0  0          ","                   ","     0  0          ","     00 00         ",
        };



        public static string[] level1 = {
            "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", // 0
            "00000000000000                0000000000000000000000000000000                             0000000000", // 1
            "00000                            0000         000000000000                                   0000000", // 2
            "0000                              0             0000000                                        00000", // 3
            "0000                                            000000        You can kill an enemy by          0000", // 4
            "0000             Arrow keys to move             000000      going into them but you will        0000", // 5
            "00000                                          0000000             loose a life.                0000", // 6
            "00000000000000      00                         0000000                                          0000", // 7
            "0000    00000000000000                       0000000000                                        00000", // 8
            "00000                                       00000000000000                                   0000000", // 9
            "000000000                                00000000000000000000                             0000000000", // 10
            Rep('0',100),Rep('0',100),
            "0000                                        0000000000                                         00000", // 13
            "000                                          00000000                                           0000", // 14
            "000                                          00000000                                           0000", // 15
            "000         These guys shoot things          00000000                                           0000", // 16
            "000       And those are not good things      00000000         Also they are invincible          0000", // 17
            "000                                          00000000                                           0000", // 18
            "000                                          00000000                                           0000", // 19
            "000                                          00000000                                           0000", // 20
            "000                                         0000000000                                          0000", // 21
            "0000                                                                                           00000", // 22
            Rep('0',100),Rep('0',100),
            GetCircle(0),GetCircle(1),Rep('0',18)+"               You need to collect all the potions              "+Rep('0',18),
            GetCircle(3),GetCircle(4),GetCircle(5),GetCircle(6),GetCircle(7),GetCircle(8),GetCircle(9),GetCircle(10),GetCircle(11),
            GetCircle(12),GetCircle(13),GetCircle(14),GetCircle(15),GetCircle(16),GetCircle(16),GetCircle(18),GetCircle(19),
            GetCircle(20),GetCircle(21),GetCircle(22),GetCircle(23),GetCircle(24),GetCircle(25),GetCircle(26),GetCircle(27),GetCircle(28),
            Rep('0',100),Rep('0',100),
            "00000                          000000                          000000                          00000", // 56
            "0000                            0000                            0000                            0000", // 57
            "0000                            0000                            0000                            0000", // 58 
            "0000     Cannons and bombs      0000                            0000                            0000", // 59
            "0000                            0000                            0000                            0000", // 60
            "0000                            0000                            0000                            0000", // 61
            "0000                            0000                            0000                            0000", // 62
            "0000                                                                                            0000", // 63
            "0000                            0000                            0000                            0000", // 64
            "00000                          000000                          000000                          00000", // 65
            Rep('0', 100),Rep('0', 100),
            "000                                                                                              000", // 68
            "000                                                                                              000", // 69
            "000                                                                                              000", // 70
            "000                                                                                              000", // 71
            "000         0 0                                                                     0 0          000", // 73
            "000                                                                                              000", // 74
            "000         0 0                                                                     0 0          000", // 72
            "000                                                                                              000", // 75
            "000                                                                                              000", // 76
            "000                                         000 0 0 000                                          000", // 77
            "000                                         00       00                                          000", // 78
            "000                                                                                              000", // 79
            "000                                         00       00                                          000", // 80
            "000                                         000 0 0 000                                          000", // 81
            "000                                                                                              000", // 82
            "000                                                                                              000", // 83
            "000         0 0                                                                     0 0          000", // 84
            "000                                                                                              000", // 85
            "000         0 0                                                                     0 0          000", // 86
            "000                                                                                              000", // 87
            "000                                                                                              000", // 88
            "000                                                                                              000", // 89
            "000                                                                                              000", // 90
            Rep('0',100),"","","","","","","","","","","","","","","","","","","","","","","","",Rep('0',100),
            "0                                                                                                  0", // 117
            "0                                       Thank you for playing                                      0", // 118
            "0                         This is a game made by CatonIf in \\2\\0 hours (4 days)                      0", // 119
            "0                                for the Terminal Jam on itch.io.                                  0", // 120
            "0                     This game was made without any engine, just with a text editor               0", // 121
            "0                        and it's compatible with the command prompt of your PC.                   0", // 122
            "0                                         Hope you liked it.                                       0", // 123
            "0                                                                                                  0", // 124
            "0                                    Press ESC to exit the game                                    0", // 125
            "0                                                                                                  0", // 126
            "0                                                                                                  0", // 127
            "0                                                                                                  0", // 128
            "0                           Maybe I will release the code on GitHub later.                         0", // 129
            "0                                                                                                  0", // 130
            Rep('0',100)
        };

        static void SpawnEnemies() {
            entities.Clear();
            collectables.Clear();
            squareBoss = null;
            switch (currentLevel) {
                case 0: CreateNewTeleport(new Coord(33, 9), new Coord(74, 8)); break;
                case 1: entities.Add(new Entity(EntityType.Walker, new Coord(74, 3))); break;
                case 2:
                    entities.Add(new Entity(EntityType.Shooter, new Coord(9, 22)));
                    entities.Add(new Entity(EntityType.Shooter, new Coord(74, 20)));
                    entities.Add(new Entity(EntityType.Shooter, new Coord(74, 18)));
                    CreateNewTeleport(new Coord(74, 15), new Coord(18, 30));
                    break;
                case 3:
                    CreateCollectable(new Coord(40, 35));
                    entities.Add(new Entity(EntityType.Tetra, new Coord(50, 40)));
                    entities.Add(new Entity(EntityType.Shooter, new Coord(35, 31))); // ul
                    entities.Add(new Entity(EntityType.Shooter, new Coord(34, 50))); // dl
                    entities.Add(new Entity(EntityType.Shooter, new Coord(66, 30))); // ur
                    entities.Add(new Entity(EntityType.Shooter, new Coord(65, 51))); // dr
                    break;
                case 4: entities.Add(new Entity(EntityType.Cannon, new Coord(50, 60))); CreateCollectable(new Coord(80, 60)); break;
                case 5: squareBoss = new Square(new Coord(49, 85)); CreateCollectable(new Coord(49, 88)); break;
            }
        }

        static void WhenOnCollectable(Coord c) {
            if (collectables.Count != 0) {
                if (player.pos == collectables[0]) {
                    collectables.RemoveAt(0);
                    if (player.pos == new Coord(40, 35)) CreateCollectable(new Coord(60, 45));
                    if (player.pos == new Coord(60, 45)) CreateCollectable(new Coord(40, 36));
                    if (player.pos == new Coord(40, 36)) { CreateNewTeleport(entities.Find(item => item.type == EntityType.Tetra).pos, new Coord(20, 60)); entities.Clear(); }
                    if (player.pos == new Coord(80, 60)) CreateNewTeleport(new Coord(20, 60), new Coord(49, 74));
                    if (player.pos == new Coord(49, 88)) {
                        SetTile(player.pos, ' ');
                        entities.Add(new Entity(EntityType.Tetra, new Coord(49, 79)));
                        entities.Add(new Entity(EntityType.Shooter, new Coord(13, 73)));
                        entities.Add(new Entity(EntityType.Shooter, new Coord(85, 73)));
                        entities.Add(new Entity(EntityType.Shooter, new Coord(13, 85)));
                        entities.Add(new Entity(EntityType.Shooter, new Coord(85, 85)));
                        CreateNewTeleport(new Coord(11, 75), new Coord(10, 118));
                    }
                }
            }
        }

        public static Coord playerStartPos = new Coord(10, 5);
        public static Entity player = new Entity(EntityType.Player, playerStartPos);

        public static string GetCircle(int i){
            int[] circle = { 14, 11, 9, 7, 6, 6, 5, 5, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 9, 11, 14 };
            return Rep('0', circle[i] * 2) + Rep(' ', 100 - circle[i] * 4) + Rep('0', circle[i] * 2);
        }

        public static string Rep(char c, int t) { string s = ""; for (int i = 0; i < t; i++) s += c; return s; }

        public static void Die() {
            Console.Clear(); Console.Write("You are dead, press R to restart.");
            char k = ' '; while (k != 'r') k = Console.ReadKey(true).KeyChar;
            TrueMain();
        }

        public static char GetTile(Coord c, bool p = false) => GetTile(c.x, c.y, p);
        public static char GetGrossTile(Coord c) => level1[c.y][c.x];

        public static char GetTile(int x, int y, bool p = false) {
            if (!p && new Coord(x, y) == player.pos) {
                Console.ForegroundColor = ConsoleColor.Green;
                return player.GetByDirection(player.dir);
            }
            char r = level1[y][x];
            ConsoleColor c = ConsoleColor.Yellow;
            switch (r) {
                case '0': c = ConsoleColor.DarkMagenta; r = '█'; break;
                case '1': c = ConsoleColor.Cyan; r = '▒'; break;
                case '2': c = ConsoleColor.DarkCyan; r = '░'; break;
            } Console.ForegroundColor = c; return r;
        }

        public class Teleport {
            public Coord position, direction; public Teleport(Coord cPosition, Coord cDirection) { position = cPosition; direction = cDirection; }
        }

        public static List<Teleport> teleports = new List<Teleport>();
        public static List<Entity> entities = new List<Entity>();
        public static Square squareBoss = null;
        public static List<Coord> collectables = new List<Coord>();

        public static bool music = true;
        public static bool gotHit = false;
        public static int playerLife = 5;
        public static int currentLevel = 0;
        public static int pastLife = 0;

        static void Main(string[] args) {
            Debug.Write(level1.Length);
            Size(new Coord(120, 31));
            SetConsoleOutputCP(65001);
            SetConsoleCP(65001);
            int i = Logo();
            if (i == 0) return;
        }

        static int Logo() {
            Console.Write("\n"+Rep(' ', 5));
            foreach (string s in pixelArt) {
                char[] cs = s.ToCharArray();
                foreach (char c in cs) {
                    if (c == ' ') Console.BackgroundColor = ConsoleColor.Black;
                    else Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                } new Coord(Console.CursorLeft - s.Length*2, Console.CursorTop + 1).Set();
            } new Coord(50, 1).Write("The Man With A Spear", ConsoleColor.Green);
            new Coord(50, 4).Write("Press P to play.");
            new Coord(50, 6).Write("Press M to mute the music.");
            new Coord(50, 8).Write("Press ESC to quit.");
            while (true) {
                ConsoleKey k = Console.ReadKey(true).Key;
                switch(k) {
                    case ConsoleKey.P:
                        if (music) Music.mainTheme.Start();
                        TrueMain();
                        return 0;
                    case ConsoleKey.M:
                        music = !music;
                        new Coord(50, 6).Write("Press M to " + (music ? "mute" : "unmute") + " the music.  ");
                        break;
                    case ConsoleKey.Escape:
                        return 0;
                }
            }
        }

        static void SetTile(Coord c, char s) {
            c.Write(s);
            StringBuilder sb = new StringBuilder(level1[c.y]);
            sb[c.x] = s;
        }

        static void Size(Coord c) {
            Console.WindowWidth = c.x;
            Console.WindowHeight = c.y;
            int zero = 0x00000000;
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, zero);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF030, zero);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF000, zero);
        }

        static void CreateCollectable(Coord c) {
            collectables.Add(c);
            SetTile(c,'g');
            Console.ForegroundColor = ConsoleColor.Cyan;
            c.Write('g');
        }

        public static void TakeDamage(int damage = 1) {
            playerLife -= damage;
            if (!gotHit) {
                gotHit = true;
                CreateNewTeleport(new Coord(74,2),new Coord(18,20));
            } if (playerLife == 0) Die();
        }

        public static void CreateNewTeleport(Coord pos, Coord des) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            teleports.Add(new Teleport(pos, des));
            pos.Write('▒');
            StringBuilder sb = new StringBuilder(level1[pos.y]);
            sb[pos.x] = '1';
            level1[pos.y] = sb.ToString();
        }

        private static void TrueMain() {
            playerLife = 5;
            Console.CursorVisible = false;
            Console.Clear();
            entities = new List<Entity>();
            squareBoss = null;
            Load();
            SpawnEnemies();
            while (true) {
                player.Display();
                foreach (Entity e in entities) e.Display();
                if (squareBoss != null) squareBoss.Display();
                WhenOnCollectable(player.pos);
                for (int i = 0; i < teleports.Count; i++) {
                    if (teleports[i].position == player.pos) {
                        player.pos.Write(GetTile(player.pos, true));
                        player.pos = teleports[i].direction;
                        teleports[i].direction.Write(player.GetByDirection(player.dir));
                        playerStartPos = teleports[i].direction;
                        currentLevel = i + 1;
                        SpawnEnemies();
                    }
                }
                Coord c = new Coord(105, player.pos.y);
                Console.ForegroundColor = ConsoleColor.White;
                new Coord(105, pastLife).Write("              ");
                c.Write("Life: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < playerLife; i++) Console.Write('█');
                pastLife = c.y;
                ConsoleKey q = Console.ReadKey(true).Key;
                switch (q) {
                    case ConsoleKey.DownArrow: player.dir = Coord.Down; break;
                    case ConsoleKey.RightArrow: player.dir = Coord.Right; break;
                    case ConsoleKey.LeftArrow: player.dir = Coord.Left; break;
                    case ConsoleKey.UpArrow: player.dir = Coord.Up; break;
                    case ConsoleKey.Escape: Music.mainTheme.Abort(); return;
                    case ConsoleKey.M:if(music)Music.mainTheme.Suspend();else{if(Music.mainTheme.IsAlive)Music.mainTheme.Resume();else Music.mainTheme.Start();}music=!music;break;
                }
            }
        }

        public static void MakeInvisibleWall(Coord c) {
            StringBuilder sb = new StringBuilder(level1[c.y]);
            sb[c.x] = '0';
            level1[c.y] = sb.ToString();
        }

        public static void Load() {
            new Coord().Set();
            foreach (string s in level1) {
                char[] cs = s.Replace('0', '█').Replace('1', '▒').Replace('2', '░').Replace("\\█", "0").Replace("\\░", "2").ToCharArray();
                foreach (char c in cs) {
                    if (c == '█') Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else if (c == '▒') Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (c == '░') Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(c);
                } Console.Write("\n");
            } Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static int NearerBetweenThree(int n, int o1, int o2, int o3) {
            int m1 = Math.Abs(n - o1), m2 = Math.Abs(n - o2), m3 = Math.Abs(n - o3);
            int i = 0;
            if (m1 > m2) i = 1;
            if (m1 > m3 && m2 > m3) i = 2;
            return i;
        }
    } 

    class Coord {

        public int x, y;

        public Coord(int fX = 0, int fY = 0) { x = fX; y = fY; }

        public void Write(string s, ConsoleColor c = ConsoleColor.Black) { if (c != 0) Console.ForegroundColor = c; Set(); Console.Write(s); }
        public void Write(char c) { Set(); Console.Write(c); }

        public void Set() => Console.SetCursorPosition(x, y);

        public Coord PointThePlayer() {
            Coord d = Program.player.pos - this;
            if (Math.Abs(d.y) > Math.Abs(d.x)) return (Program.player.pos.y > y) ? Down : Up;
            else return (Program.player.pos.x > x) ? Right : Left;
        }

        // Basic operators
        public static bool operator ==(Coord a, Coord b) => (a.x == b.x) && (a.y == b.y);
        public static bool operator !=(Coord a, Coord b) => !(a == b);
        public static Coord operator +(Coord a, Coord b) => new Coord(a.x + b.x, a.y + b.y);
        public static Coord operator -(Coord a, Coord b) => new Coord(a.x - b.x, a.y - b.y);

        // Useful constants
        public readonly static Coord Up = new Coord(0, -1);
        public readonly static Coord Right = new Coord(1, 0);
        public readonly static Coord Down = new Coord(0, 1);
        public readonly static Coord Left = new Coord(-1, 0);
        public readonly static Coord Zero = new Coord();
    }

    enum EntityType { Player, Walker, Shooter, Bullet, Tetra, Cannon, Bomb }

    class Entity {

        public EntityType type;
        public Coord dir = Coord.Up;
        public char up, down, left, right, upRgt, upLft;
        public Coord pos = new Coord();

        public Entity(Coord startPos) {
            pos = startPos;
        }

        public Entity(EntityType fType, Coord startPos) {
            pos = startPos;
            switch (fType) {
                case EntityType.Player: up = 'A'; left = '<'; down = 'V'; right = '>'; break;
                case EntityType.Walker: up = 'M'; left = 'E'; down = 'W'; right = '3'; break;
                case EntityType.Shooter: up = down = '6'; left = right = '9'; break;
                case EntityType.Bullet: up = down = '│'; left = right = '─'; upLft = '\\'; upRgt = '/'; break;
                case EntityType.Tetra: up = 'x'; down = '+'; break;
                case EntityType.Cannon: up = 'u'; down = 'n'; left = '\u2184'; right = 'c'; break;
                case EntityType.Bomb: up = left = down = right = 'o'; break;
            }
        }

        public char GetByDirection(Coord c) {
            if (c == Coord.Right) return right;
            if (c == Coord.Down) return down;
            if (c == Coord.Left) return left;
            if (c == Coord.Up) return up;
            if (c == new Coord(-1, -1) || c == new Coord(1, 1)) return '\\';
            if (c == new Coord(1, -1) || c == new Coord(-1, 1)) return '/';
            return up;
        }

        public bool alive = true;

        void MoveTheNormal() {
            Coord target = Program.player.pos;
            CheckDead();
            if (alive) {
                Coord d = target - pos;
                if (Math.Abs(d.y) > Math.Abs(d.x)) dir = (target.y > pos.y) ? Coord.Down : Coord.Up;
                else dir = (target.x > pos.x) ? Coord.Right : Coord.Left;
                Move();
            }
        }

        void TetraPoint() {
            Coord target = Program.player.pos - pos;
            Coord wh = pos.PointThePlayer();
            if (wh.x == 0) dir = Program.NearerBetweenThree(target.x, target.y, 0, -target.y) == 1 ? Coord.Up : Coord.Down;
            if (wh.y == 0) dir = Program.NearerBetweenThree(target.y, target.x, 0, -target.x) == 1 ? Coord.Up : Coord.Down;
        }

        void BasicPoint() {
            Coord target = Program.player.pos;
            CheckDead();
            if (alive) dir = pos.PointThePlayer();
        }

        private void CheckDead() {
            Entity player = Program.player;
            if (player.pos == pos) {
                Program.entities.Remove(this);
                Console.ForegroundColor = ConsoleColor.Green;
                pos.Write(player.GetByDirection(player.dir));
                Program.TakeDamage();
                alive = false;
            }
        }

        public void Move() {
            Coord tempPos = pos + dir;
            if (Program.GetGrossTile(tempPos) != '0') pos = tempPos;
        }

        public void MoveArrow() {
            if (alive) {
                if (pos == Program.player.pos) {
                    Program.TakeDamage();
                    DestroyArrow();
                    return;
                }
                Coord tempPos = pos + dir;
                if (Program.GetGrossTile(tempPos) != '0') pos = tempPos;
                else DestroyArrow();
            }
        }

        public void DestroyArrow() {
            alive = false;
            Program.entities.Remove(this);
            pos.Write(Program.GetTile(pos));
        }

        public int delayShooter = 0;

        public void Shoot(EntityType bullet, Coord direction) {
            Program.entities.Add(new Entity(bullet, pos + direction));
            Program.entities[Program.entities.Count - 1].dir = direction;
        }




        // DISPLAY

        public void Display() {
            switch (type) {
                case EntityType.Player: DisplayPlayer(); break;
                case EntityType.Walker: DisplayWalker(); break;
                case EntityType.Shooter: DisplayShooter(); break;
                case EntityType.Bullet: DisplayBullet(); break;
                case EntityType.Tetra: DisplayTetra(); break;
                case EntityType.Cannon: DisplayCannon(); break;
                case EntityType.Bomb: DisplayBomb(); break;
            }
        }

        private void DisplayPlayer() {
            pos.Write(Program.GetTile(pos.x, pos.y, true));
            Console.ForegroundColor = ConsoleColor.Green;
            Move(); pos.Write(GetByDirection(dir));
        }

        private void DisplayWalker() {
            pos.Write(Program.GetTile(pos.x, pos.y));
            Console.ForegroundColor = ConsoleColor.Red;
            MoveTheNormal(); if (alive) pos.Write(GetByDirection(dir));
        }

        private void DisplayShooter() {
            Program.MakeInvisibleWall(pos);
            Console.ForegroundColor = ConsoleColor.Blue;
            BasicPoint(); if (alive) pos.Write(GetByDirection(dir));
            delayShooter++;
            if (delayShooter == 3) {
                delayShooter = 0;
                Shoot(EntityType.Bullet, dir);
            }
        }

        private void DisplayBullet() {
            pos.Write(Program.GetTile(pos.x, pos.y));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MoveArrow(); if (alive) pos.Write(GetByDirection(dir));
            (pos + dir).Set();
        }

        private void DisplayTetra() {
            Program.MakeInvisibleWall(pos);
            Console.ForegroundColor = ConsoleColor.White;
            TetraPoint(); if (alive) pos.Write(GetByDirection(dir));
            delayShooter++;
            if (delayShooter == 2) {
                delayShooter = 0;
                if (dir == Coord.Up) {  // if X
                    Shoot(EntityType.Bullet, Coord.Up + Coord.Right);
                    Shoot(EntityType.Bullet, Coord.Up + Coord.Left);
                    Shoot(EntityType.Bullet, Coord.Down + Coord.Right);
                    Shoot(EntityType.Bullet, Coord.Down + Coord.Left);
                } else {                // if +
                    Shoot(EntityType.Bullet, Coord.Up);
                    Shoot(EntityType.Bullet, Coord.Left);
                    Shoot(EntityType.Bullet, Coord.Right);
                    Shoot(EntityType.Bullet, Coord.Down);
                }
            }
        }

        private void DisplayCannon() {
            Program.MakeInvisibleWall(pos);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            BasicPoint(); if (alive) pos.Write(GetByDirection(dir));
            delayShooter++;
            if (delayShooter == 7) {
                delayShooter = 0;
                Shoot(EntityType.Bomb, dir);
            }
        }

        private void DisplayBomb() {
            pos.Write(Program.GetTile(pos.x, pos.y));
            Console.ForegroundColor = ConsoleColor.Red;
            MoveArrow(); if (alive) pos.Write(GetByDirection(dir));
            (pos + dir).Set();
            delayShooter++;
            if (delayShooter == 6 || !alive) {
                pos.Write(' ');
                Program.entities.Remove(this);
                alive = false;
                Shoot(EntityType.Bullet, Coord.Up);
                Shoot(EntityType.Bullet, Coord.Down);
                Shoot(EntityType.Bullet, Coord.Right);
                Shoot(EntityType.Bullet, Coord.Left);
                Shoot(EntityType.Bullet, Coord.Up + Coord.Right);
                Shoot(EntityType.Bullet, Coord.Down + Coord.Left);
                Shoot(EntityType.Bullet, Coord.Right + Coord.Down);
                Shoot(EntityType.Bullet, Coord.Left + Coord.Up);
            }
        }
    }

    class Square {

        public Coord pos;
        public List<Coord> poses = new List<Coord>();

        Coord dir;

        public static int NearerBetweenThree(int n, int o1, int o2, int o3) {
            int m1 = Math.Abs(n - o1), m2 = Math.Abs(n - o2), m3 = Math.Abs(n - o3);
            int i = 0;
            if (m1 > m2) i = 1;
            if (m1 > m3 && m2 > m3) i = 2;
            return i;
        }

        Coord SquarePoint() {
            Coord wh = pos.PointThePlayer();
            Coord target = Program.player.pos - pos;
            if (wh == Coord.Up) {
                int i = NearerBetweenThree(target.x, target.y, 0, -target.y);
                switch (i) {
                    case 0: return Coord.Up + Coord.Left;
                    case 1: return Coord.Up;
                    case 2: return Coord.Up + Coord.Right;
                }
            } else if (wh == Coord.Right) {
                int i = NearerBetweenThree(target.y, target.x, 0, -target.x);
                switch (i) {
                    case 0: return Coord.Down + Coord.Right;
                    case 1: return Coord.Right;
                    case 2: return Coord.Up + Coord.Right;
                }
            } else if (wh == Coord.Down) {
                int i = NearerBetweenThree(target.x, target.y, 0, -target.y);
                switch (i) {
                    case 0: return Coord.Down + Coord.Right;
                    case 1: return Coord.Down;
                    case 2: return Coord.Down + Coord.Left;
                }
            } else if (wh == Coord.Left) {
                int i = NearerBetweenThree(target.y, target.x, 0, -target.x);
                switch (i) {
                    case 0: return Coord.Up + Coord.Left;
                    case 1: return Coord.Left;
                    case 2: return Coord.Down + Coord.Left;
                }
            } return null;
        }

        void SetState() {
            if (dir.x == 0) state = 0;
            if (dir.y == 0) state = 1;
            if (dir.x == -dir.y) state = 2;
            if (dir.x == dir.y) state = 3;
        }

        private readonly string[] states = { "+--+|  |+--+", "+──+¦  ¦+──+", " /+\\+  +\\+/ ", "/+\\ +  + \\+/" };
        int state = 0; // 0 = vertical; 1 = horizontal; 2 = /; 3 = \; i could have made a enum, but nah

        public Square(Coord startPos) {
            pos = startPos;
            CreatePoses();
            SetPoses();
        }

        bool shooting;

        void CreatePoses() {
            for (int i = 0; i < 12; i++) poses.Add(new Coord());
        }

        void Move() {
            foreach(Coord c in poses) {
                if (Program.GetGrossTile(c + dir) == '0') return;
                else continue;
            } pos = pos + dir;
            SetPoses();
        }

        void SetPoses() {
            int i = 0;
            for (int y = -1; y < 2; y++) {
                for (int x = -2; x < 2; x++) {
                    poses[i] = pos + new Coord(x, y);
                    i++;
                }
            }
        }

        Coord GetInPosesDirection(Coord dir) {
            if (dir == Coord.Up) return poses[1];
            if (dir == (Coord.Up + Coord.Right)) return poses[3];
            if (dir == Coord.Right) return poses[7];
            if (dir == (Coord.Right + Coord.Down)) return poses[11];
            if (dir == Coord.Down) return poses[9];
            if (dir == (Coord.Down + Coord.Left)) return poses[8];
            if (dir == Coord.Left) return poses[4];
            return poses[0];

        }

        private void SpinShooting() {
            Entity e = new Entity(pos);
            switch (delayShooter) {
                case 8:  case 0: e.Shoot(EntityType.Bullet, Coord.Up); break;
                case 9:  case 1: e.Shoot(EntityType.Bullet, Coord.Up + Coord.Right); break;
                case 10: case 2: e.Shoot(EntityType.Bullet, Coord.Right); break;
                case 11: case 3: e.Shoot(EntityType.Bullet, Coord.Right + Coord.Down); break;
                case 12: case 4: e.Shoot(EntityType.Bullet, Coord.Down); break;
                case 13: case 5: e.Shoot(EntityType.Bullet, Coord.Down + Coord.Left); break;
                case 14: case 6: e.Shoot(EntityType.Bullet, Coord.Left); break;
                case 15: case 7: e.Shoot(EntityType.Bullet, Coord.Left + Coord.Up); break;
                    
            }
        }

        public void Display() {
            dir = SquarePoint();
            SetState();
            Clear();
            if (shooting) SpinShooting();
            else Move();
            Write();
            CheckKill();
            delayShooter++;
            if (delayShooter == 16) {
                delayShooter = 0;
                shooting = !shooting;
            }
        }

        int delayShooter = 0;

        void CheckKill() {
            foreach (Coord c in poses) {
                if (c == Program.player.pos) Program.Die();
                else continue;
            }
        }

        private void Clear() {
            foreach (Coord p in poses) p.Write(' ');
        }

        public void Write() {
            Console.ForegroundColor = shooting ? ConsoleColor.Blue : ConsoleColor.Red;
            for (int i = 0; i < poses.Count; i++) poses[i].Write(states[state][i]);
        }

    }

    class Music {
        public static Thread mainTheme = new Thread(
            new ThreadStart(
                delegate () {
                    while (true) {
                        for (int i = 0; i < 4; i++) {
                            Beep(Fre.e2);Beep(Fre.e4);Beep();Beep(Fre.e2);Beep(Fre.g2);Beep(Fre.g4);Beep();Beep(Fre.g2);
                            Beep(Fre.a2);Beep(Fre.e4);Beep();Beep(Fre.a2);Beep(Fre.b2);Beep(Fre.gb4);Beep();Beep(Fre.b2);
                        } for (int i = 0; i < 4; i++) {
                            Beep(Fre.e2,Dur.semi);Beep(Fre.e4,Dur.semi);Beep(Fre.g2,Dur.semi);Beep(Fre.g4,Dur.semi);
                            Beep(Fre.a2,Dur.semi);Beep(Fre.e4,Dur.semi);Beep(Fre.b2,Dur.semi);Beep(Fre.gb4,Dur.semi);
                        } for (int i = 0; i < 4; i++) {
                            Beep(Fre.e2);Beep(Fre.b4);Beep(Fre.e4);Beep(Fre.b4);Beep(Fre.g2);Beep(Fre.b4);Beep(Fre.g4);Beep(Fre.b4);
                            Beep(Fre.a2);Beep(Fre.c4);Beep(Fre.e4);Beep(Fre.c4);Beep(Fre.b2);Beep(Fre.b3);Beep(Fre.gb4);Beep(Fre.a3);
                        } for (int i = 0; i < 4; i++) {
                            Beep(Fre.e2);Beep(Fre.b2);Beep(Fre.e3);Beep(Fre.b3);Beep(Fre.g2);Beep(Fre.b2);Beep(Fre.d3);Beep(Fre.b3);
                            Beep(Fre.a2);Beep(Fre.e3);Beep(Fre.a3);Beep(Fre.e4);Beep(Fre.b2);if(i<3){Beep(Fre.eb3);Beep(Fre.a3);Beep(Fre.eb4);}else Beep(Fre.no, Dur.punt);
                        }
                    }
                }
            )
        );

        private static void Beep(Fre freq = Fre.no, Dur dura = Dur.crom) {
            if (freq != Fre.no) Console.Beep((int)freq, (int)dura);
            else Thread.Sleep((int)dura);
        }

        private enum Fre{no=0,e2=82,g2=98,a2=110,b2=123,d3=146,eb3=155,e3=164,a3=220,b3=246,c4=261,eb4=311,e4=329,gb4=369,g4=392,b4=493}
        private enum Dur{semi=800,crom=semi/2,punt=crom*3}

    }
}
