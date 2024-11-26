using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingHotel.Models
{
    public partial class BHContext : DbContext
    {
        public BHContext()
        {
        }

        public BHContext(DbContextOptions<BHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Footer> Footers { get; set; } = null!;
        public virtual DbSet<Header> Headers { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<SupportOnline> SupportOnlines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1RFICID\\SQLEXPRESS;Database=BH;Integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountAbout).HasColumnName("account_about");

                entity.Property(e => e.AccountAddress)
                    .HasMaxLength(200)
                    .HasColumnName("account_address");

                entity.Property(e => e.AccountEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_email");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(100)
                    .HasColumnName("account_name");

                entity.Property(e => e.AccountPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_password");

                entity.Property(e => e.AccountPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_phone");

                entity.Property(e => e.AccountTimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("account_timeCreate");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Accounts_Positions");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookingEndDate)
                    .HasColumnType("date")
                    .HasColumnName("booking_end_date");

                entity.Property(e => e.BookingStartDate)
                    .HasColumnType("date")
                    .HasColumnName("booking_start_date");

                entity.Property(e => e.BookingTimeCreate)
                    .HasColumnType("date")
                    .HasColumnName("booking_timeCreate");

                entity.Property(e => e.BookingTotalMoney).HasColumnName("booking_totalMoney");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .HasColumnName("customer_email");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Bookings_Payments");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Bookings__room_i__3D5E1FD2");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Bookings_Status");
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.HotelAddress)
                    .HasMaxLength(200)
                    .HasColumnName("hotel_address");

                entity.Property(e => e.HotelArea)
                    .HasMaxLength(50)
                    .HasColumnName("hotel_area");

                entity.Property(e => e.HotelDescription).HasColumnName("hotel_description");

                entity.Property(e => e.HotelFlag).HasColumnName("hotel_flag");

                entity.Property(e => e.HotelImage).HasColumnName("hotel_image");

                entity.Property(e => e.HotelMoreImage).HasColumnName("hotel_moreImage");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(100)
                    .HasColumnName("hotel_name");

                entity.Property(e => e.HotelPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("hotel_phone");

                entity.Property(e => e.HotelPrice).HasColumnName("hotel_price");

                entity.Property(e => e.HotelTimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("hotel_timeCreate");

                entity.Property(e => e.HotelType)
                    .HasMaxLength(50)
                    .HasColumnName("hotel_type");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Target).HasMaxLength(10);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Title1).HasMaxLength(100);

                entity.Property(e => e.Title2).HasMaxLength(100);

                entity.Property(e => e.Title3).HasMaxLength(100);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PaymentAmount)
                    .HasMaxLength(50)
                    .HasColumnName("payment_amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .HasColumnName("payment_type");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(50)
                    .HasColumnName("position_name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.RoomBed)
                    .HasMaxLength(50)
                    .HasColumnName("room_bed");

                entity.Property(e => e.RoomImage)
                    .HasMaxLength(500)
                    .HasColumnName("room_image");

                entity.Property(e => e.RoomMoreImage)
                    .HasMaxLength(250)
                    .HasColumnName("room_moreImage");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(100)
                    .HasColumnName("room_name");

                entity.Property(e => e.RoomPerson)
                    .HasMaxLength(100)
                    .HasColumnName("room_person");

                entity.Property(e => e.RoomPrice).HasColumnName("room_price");

                entity.Property(e => e.RoomService)
                    .HasMaxLength(500)
                    .HasColumnName("room_service");

                entity.Property(e => e.RoomSize)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("room_size");

                entity.Property(e => e.RoomStatus).HasColumnName("room_status");

                entity.Property(e => e.RoomTimeCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("room_timeCreate");

                entity.Property(e => e.RoomUtilities)
                    .HasMaxLength(100)
                    .HasColumnName("room_utilities");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Rooms__hotel_id__3A81B327");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(100)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<SupportOnline>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
